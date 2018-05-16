using NHAHANG_RIENG.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAHANG_RIENG.DAO
{
    class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO();
                return BillDAO.instance; }
           private set { BillDAO.instance = value; }
        }

        private BillDAO()
        {

        }

        // thành cồng : bill ID
        // thất bại: -1

        public  int GetUncheckBillIdByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from dbo.BILL where IDTABLE = "+id+ "  and status = 0");
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExcuteNonQuery("exec USP_InsertBill  @IDTABLE ", new object[] { id });
        }
        public void DelBill(int id)
        {
            DataProvider.Instance.ExcuteNonQuery("exec USP_DelBill  @IDTABLE ", new object[] { id });
        }

        public void CheckOut(int id,int giamgia, float tongtien_hoadon, float tongtien_thanhtoan)
        {
            string query = "UPDATE dbo.BILL set DATECHECKOUT = GETDATE(), STATUS =1," + "GIAMGIA=" + giamgia + ", TONGTIEN_HOADON =" + tongtien_hoadon +", TONGTIEN_THANHTOAN ="+ tongtien_thanhtoan + " where id ="+id;
            DataProvider.Instance.ExcuteQuery(query);
        }

        // HÀM THỐNG KÊ DS HÓA ĐƠN THEO NGÀY
        public DataTable GetListBillByDate(DateTime checkin, DateTime checkout)
        {
            return DataProvider.Instance.ExcuteQuery("EXEC USP_GETLISTBILLBYDATE @DATECHECKIN , @DATECHECKOUT", new object[] {checkin, checkout });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteScalar("select MAX(ID) from DBO.BILL");
           
            }
            catch
            {
                return 1;
            }
        }

        // THỐNG KE HÓA ĐƠN THEO NGÀY
        public int GetNumberBillByDate(DateTime checkin, DateTime checkout)
        {

            return (int)DataProvider.Instance.ExcuteScalar("EXEC USP_GETNUMBERBILL @DATECHECKIN , @DATECHECKOUT", new object[] { checkin, checkout });
        }


        // TÍNH TỔNG THU THEO HD (CHƯA TÍNH GIẢM GIÁ, ...)
        public string TotalPrices_HD(DateTime checkin, DateTime checkout)
        {
            return (string)DataProvider.Instance.ExcuteScalarToDouble("EXEC USP_TotalPrice_HD @DATECHECKIN , @DATECHECKOUT", new object[] { checkin, checkout });
        }


        // TÍNH TỔNG THU THEO THỰC TẾ (ĐÃ TÍNH GIẢM GIÁ, ...)
        public string TotalPrices_TT(DateTime checkin, DateTime checkout)
        {
            return (string)DataProvider.Instance.ExcuteScalarToDouble("EXEC USP_TotalPrice_TT @DATECHECKIN , @DATECHECKOUT", new object[] { checkin, checkout });
        }

        public DataTable GetListBillByDate_inPage(DateTime checkin, DateTime checkout, int pageNumber)
        {
            return DataProvider.Instance.ExcuteQuery("EXEC USP_GETLISTBILLBYDATE_IN_PAGE @DATECHECKIN , @DATECHECKOUT , @PAGE", new object[] { checkin, checkout, pageNumber });
        }

    }
}
