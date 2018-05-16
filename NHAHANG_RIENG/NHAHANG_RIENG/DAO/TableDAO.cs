using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using NHAHANG_RIENG.DTO;

namespace NHAHANG_RIENG.DAO
{
   public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get
            { 
                if (instance == null) instance = new TableDAO();
                return TableDAO.instance;
            }
             private set { TableDAO.instance = value; }
        }
        public static int TableWidth = 110;
        public static int TableHieght = 110;




        public List<Table> LoadtableList()
        {
            List<Table> tablelist = new List<Table>();
            DataTable data;
            data = DataProvider.Instance.ExcuteQuery("USP_GetTableList");

            foreach(DataRow item in data.Rows)
            {
                Table table =new Table(item);
                tablelist.Add(table);
            }

            return tablelist;
        }
        public Table ABC(string abc)
        {
            Table table=null;

            string query = string.Format("select * from table where name like  N'{0}'", abc);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                table = new Table(item);
                return table;
            }
            return table;
        }

        // hàm đổi chuyển  2 bàn cho nhau
        public void SwitchTable(int idtable1, int idtable2)
        {
            DataProvider.Instance.ExcuteQuery("USP_SWITCHTABLE @IDTABLE_1 , @IDTABLE_2", new object[] { idtable1, idtable2 });
        }
        public void GroupTable(int idtable1, int idtable2)
        {
            DataProvider.Instance.ExcuteQuery("USP_GROUPTABLE @IDTABLE_1 , @IDTABLE_2", new object[] { idtable1, idtable2 });
        }
        public bool InsertTable(string name, string status)
        {
            string query = String.Format("INSERT DBO.TABLEFOOD(NAME, STATUS) VALUES(N'{0}', N'{1}')", name, status);
            int kq = DataProvider.Instance.ExcuteNonQuery(query);
            return kq > 0;
        }

        public bool UpdateTable(int id, string name)
        {
            string query = String.Format("UPDATE DBO.TableFood SET NAME = N'{0}' WHERE ID = N'{1}'", name, id);
            int kq = DataProvider.Instance.ExcuteNonQuery(query);
            return kq > 0;
        }



        public bool DeleteTable(int id)
        {

            string query = string.Format("Delete TABLEFOOD where ID = N'{0}'", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
        public Table GetTableByName(string Name)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from tablefood where Name ='" + Name + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Table(item);
            }
            return null;
        }
    }
}










