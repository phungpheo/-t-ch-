using NHAHANG_RIENG.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NHAHANG_RIENG.DAO
{
    public class BanDatDAO
    {
        public static BanDatDAO instance;
        public static BanDatDAO Instance
        {
            get
            {
                if (instance == null) instance = new BanDatDAO();
                return BanDatDAO.instance;
            }
            private set => instance = value;
        }
        private BanDatDAO() { }
        public List<BanDat> GetListBanDat()
        {
            List<BanDat> list = new List<BanDat>();

            string query = "GETLISTBANDAT @sdt="+1;

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BanDat bd = new BanDat(item);
                list.Add(bd);
            }
            return list;
        }
        
        public BanDat GetBanDatById(int id)
        {
            BanDat ban = null;
            string query = "SHOWBANDATBYID @id=" + id;
            DataTable data;
            data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ban = new BanDat(item);
                return ban;
            }

            return ban;
        }
        public bool InsertBanDat(string tenkh, string sdt, int id, int sokhach, string gio, string ngay, string ghichu)
        {
            string query = String.Format("INSERT DBO.BANDAT(TENKH, SDT, IDBAN, SOKHACH, GIO, NGAY, GHICHU) VALUES(N'{0}', N'{1}', {2}, {3} , N'{4}', '{5}', N'{6}')", tenkh, sdt, id, sokhach, gio, ngay, ghichu );
            int kq = DataProvider.Instance.ExcuteNonQuery(query);
            return kq > 0;
        }
        public bool UpdateBanDat(string tenkh, string sdt, int idban, int sokhach, string gio, string ngay, string ghichu, int id)
        {
            string query = String.Format("UPDATE DBO.BANDAT SET TENKH = N'{0}', SDT= N'{1}', IDBAN = {2}, SOKHACH = {3}, GIO= N'{4}', NGAY= '{5}', GHICHU= N'{6}' where id= {7}", tenkh, sdt, idban, sokhach, gio, ngay, ghichu, id );
            int kq = DataProvider.Instance.ExcuteNonQuery(query);
            return kq > 0;
        }
        public bool DeleteBanDat(int id)
        {

            string query = string.Format("Delete bandat where id = {0}", id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
    }
}
