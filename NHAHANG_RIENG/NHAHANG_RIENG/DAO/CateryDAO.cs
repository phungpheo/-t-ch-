using NHAHANG_RIENG.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAHANG_RIENG.DAO
{
    public class CateryDAO
    {
        private static CateryDAO instance;

        public static CateryDAO Instance
        {
            get
            {
                if (instance == null) instance = new CateryDAO();
                return CateryDAO.instance;
            }
           private set => instance = value;
        }
        private CateryDAO() { }

        public List<Catery> GetListCatery()
        {
            List<Catery> list = new List<Catery>();

            string query = "select * from FOODCATERY";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Catery catery = new Catery(item);
                list.Add(catery);
            }

            return list;
        }
        public Catery ABC(string abc)
        {
            Catery category = null;

            string query = string.Format("select * from FOODCATERY where name like  N'{0}'", abc);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Catery(item);
                return category;
            }
            return category;
        }
        public Catery GetCateryById(int  id)
        {
            Catery catery = null;
            string query = "select * from FoodCatery where ID =" + id;
            DataTable data;
            data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                catery = new Catery(item);
                return catery;
            }

            return catery;
        }
        public bool InsertCatery( string name)
        {
            string query = string.Format("Insert dbo.FOODCATERY (NAME) values (N'{0}')", name);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool EditCatery(int id, string name)
        {
            string query = string.Format("update dbo.FOODCATERY set NAME=N'{0}' WHERE ID={1}", name, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;

        }
        public bool DeleteCatery(int id)
        {
            BillInfoDAO.Instance.DeleteBillInforByFoofID(id);
            string query = string.Format("DELETE  dbo.FOODCATERY where ID=" + id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
