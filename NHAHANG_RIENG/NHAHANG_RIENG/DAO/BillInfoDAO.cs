using NHAHANG_RIENG.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAHANG_RIENG.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillInfoDAO();
                return BillInfoDAO.instance;
            }
           private set => instance = value;
        }

        private BillInfoDAO()
        {

        }

        public void DeleteBillInfoByFoodID(int idfood)
        {
            DataProvider.Instance.ExcuteQuery("DELETE DBO.BILLINFO WHERE IDFOOD ="+idfood);
        }

        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from dbo.BILLINFO where IDBILL = "+id);
            foreach (DataRow  item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }

           /* pubic bool CheckFoodByTableID (int idtable)
            {
                string query = String.Format("Select");
            }*/

            return listBillInfo;
        }

        public void InsertBillInfo(int idBill,int idFood,int count)
        {
            DataProvider.Instance.ExcuteNonQuery("exec USP_InsertBillInfo @IDBILL , @IDFOOD , @COUNT", new object[] { idBill , idFood , count });
        }
        public void DeleteBillInforByFoofID(int id)
        {
            DataProvider.Instance.ExcuteNonQuery("delete dbo.BILLINFO where IDFOOD=" + id);
        }

    }
}
