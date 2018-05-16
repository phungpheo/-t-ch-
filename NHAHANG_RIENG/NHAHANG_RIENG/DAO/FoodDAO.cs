using NHAHANG_RIENG.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NHAHANG_RIENG.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null) instance = new FoodDAO();
                return FoodDAO.instance;
            }
            private set => instance = value;
        }
        public FoodDAO()
        {

        }

        public List<Food> GetFoodByCateryID(int id)
        {
            List<Food> list = new List<Food>();
            string query = "SHOWFOODBYCATERYID @idcatery=" + id ;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

        public List<Food> GetListFood()
        {
            List<Food> list = new List<Food>();
            string query = "EXEC SHOWFOOD_CATERY @IDFOOD =" + 3;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }


        // Thêm món ăn
        public bool InsertFood(string name, int idcatery, float gia)
        {
            //  string query = String.Format("EXEC INSERTFOOD @NAME , @IDCATERY , @GIA", new object[] { name, idcatery, gia });
            /* string query = "EXEC INSERTFOOD @NAME , @IDCATERY , @GIA";
             string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=QUANLYNHAHANG;Integrated Security=True";
             SqlConnection con = new SqlConnection(strCon); con.Open();
             SqlCommand cmd = new SqlCommand(query, con);
             cmd.Parameters.Add(new SqlParameter("@NAME", name));
             cmd.Parameters.Add(new SqlParameter("@IDCATERY", idcatery));
             cmd.Parameters.Add(new SqlParameter("@GIA", gia));
             int kq= cmd.ExecuteNonQuery();*/

            string query = String.Format("INSERT DBO.FOOD(NAME, IDCATERY, GIA) VALUES(N'{0}', {1}, {2})", name, idcatery, gia);
            int kq = DataProvider.Instance.ExcuteNonQuery(query);
            return kq > 0;
        }

        public bool UpdateFood(int idfood,string name, int idcatery, float gia)
        {
            string query = String.Format("UPDATE DBO.FOOD SET NAME = N'{0}', IDCATERY = {1}, GIA = {2} WHERE ID = {3}", name, idcatery, gia, idfood);
            int kq = DataProvider.Instance.ExcuteNonQuery(query);
            return kq > 0;
        }


       
        public bool DeleteFood(int idFood)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idFood);

            string query = string.Format("Delete Food where id = {0}", idFood);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        public List<Food> SearchFoodByName(string name)
        {
            List<Food> list = new List<Food>();
            string query = String.Format("SELECT a.ID ,a.NAME as 'Name' , B.NAME as 'Catery', A.GIA as 'Gia' FROM DBO.FOOD a, DBO.FOODCATERY B  where a.IDCATERY=b.ID and a.name like N'%" + name +"%'");
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }






    }
}
