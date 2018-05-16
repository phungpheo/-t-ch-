using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace NHAHANG_RIENG.DAO
{
    class DataProvider
    {
        public string sqlstringconnect = @"Data Source=.\SQLEXPRESS;Initial Catalog=QUANLYNHAHANG;Integrated Security=True";

        public void Conect()
        {
            SqlConnection con = new SqlConnection(sqlstringconnect);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                
                
            }
        }
      
        private static DataProvider instance; // Đóng gói : Ctrl + R + E
        //
        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider();
                return DataProvider.instance;
            }
            private set => instance = value;
        }


        private DataProvider() { }

        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connect = new SqlConnection(sqlstringconnect))
            {
                connect.Open();
                SqlCommand comd = new SqlCommand(query, connect);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            comd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }

                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(comd);

                adapter.Fill(dt);
                connect.Close();
                return dt;
            }

        }

        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connect = new SqlConnection(sqlstringconnect))
            {
                connect.Open();
                SqlCommand comd = new SqlCommand(query, connect);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            comd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = comd.ExecuteNonQuery();

                connect.Close();
                return data;
            }
        }

        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object dt = 0;
            using (SqlConnection connect = new SqlConnection(sqlstringconnect))
            {
                connect.Open();
                SqlCommand comd = new SqlCommand(query, connect);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            comd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }

                    }
                }
                dt = comd.ExecuteScalar();
                connect.Close();
                return dt;
            }
        }
        public object ExcuteScalarToDouble(string query, object[] parameter = null)
        {
            object dt = 0;
            using (SqlConnection connect = new SqlConnection(sqlstringconnect))
            {
                connect.Open();
                SqlCommand comd = new SqlCommand(query, connect);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            comd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }

                    }
                }
                dt = comd.ExecuteScalar().ToString();
                connect.Close();
                return dt;
            }
        }

    }
}

