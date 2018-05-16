using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAHANG_RIENG.DTO
{
    public class Account
    {

        public Account(string userName, string fullName, int type, string password, string linkavt)
        {
            this.UserName = userName;
            this.FullName = fullName;
            this.Type = type;
            this.PassWord = password;
            this.Avt = linkavt;
        }

        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.FullName = row["fullName"].ToString();
            this.Type = (int)row["type"];
            this.PassWord = row["passWord"].ToString();
            this.Avt = row["avt"].ToString();
        }


        private int type;
        private string passWord;
        private string fullName;
        private string userName;

        private string avt;

        public string UserName { get => userName; set => userName = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int Type { get => type; set => type = value; }
        public string Avt { get => avt; set => avt = value; }
    }
}
