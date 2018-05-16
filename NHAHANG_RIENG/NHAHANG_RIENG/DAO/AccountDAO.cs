using NHAHANG_RIENG.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NHAHANG_RIENG.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO();
                return instance;
            }
            private set => instance = value;
        }

        private AccountDAO() { }
        
        public bool Dangnhap(string username, string password)
        {
            string query = "USP_Login @username , @password";
            DataTable result;
            result = DataProvider.Instance.ExcuteQuery(query, new object[]{username, password});
            return result.Rows.Count > 0;
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from ACCOUNT where userName ='"+userName+"'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public bool UpdateAcc(string username, string fullname, string pass, string newpass, string LinkAvt = null)
        {
            int kq = DataProvider.Instance.ExcuteNonQuery("exec USP_UpdateAcc @username , @fullname , @password , @newpass , @linkavt ", new object[] {username ,fullname ,pass ,newpass ,LinkAvt});

            return kq > 0;

        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT FULLNAME , USERNAME, TYPE FROM ACCOUNT");
        }


        public bool InsertAccount(string username, string fullname, float type)
        {
            string query = String.Format("INSERT DBO.ACCOUNT(FULLNAME, USERNAME, TYPE) VALUES(N'{0}', N'{1}', {2})", fullname, username, type);
            int kq = DataProvider.Instance.ExcuteNonQuery(query);
            return kq > 0;
        }

        public bool UpdateAccount(string username, string fullname, float type)
        {
            string query = String.Format("UPDATE DBO.ACCOUNT SET FULLNAME = N'{0}', TYPE = {1} WHERE USERNAME = N'{2}'", fullname, type, username);
            int kq = DataProvider.Instance.ExcuteNonQuery(query);
            return kq > 0;
        }



        public bool DeleteAccount(string username)
        {
            
            string query = string.Format("Delete ACCOUNT where USERNAME = N'{0}'", username);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string username)
        {
            string query = string.Format("update ACCOUNT set PASSWORD = N'1111' where USERNAME = N'{0}'", username);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
    }
}
