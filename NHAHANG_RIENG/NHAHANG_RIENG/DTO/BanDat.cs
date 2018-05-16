using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NHAHANG_RIENG.DTO
{
    public class BanDat
    {
       /* private string tenkh, sdt, ban, ghichu;
        private int sokhach;
        private DateTime den, di, ngay;*/
        public int ID { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string Ban { get; set; }
        public int SoKhach { get; set; }
        public string Gio { get; set; }
        public string Ngay { get; set; }
        public string GhiChu { get; set; }

        public BanDat(int id ,string tenKH, string sdt, string ban, int sokhach, string gio, string ngay, string ghichu)
        {
            this.ID = id;
            this.TenKH = tenKH;
            this.SDT = sdt;
            this.Ban = ban;
            this.SoKhach = sokhach;
            this.Gio = gio;
            this.Ngay = ngay;
            this.GhiChu = ghichu;
        }
        public BanDat(DataRow row)
        {
            this.ID = (int)row["id"];
            this.TenKH = row["tenkh"].ToString();
            this.SDT = row["sdt"].ToString();
            this.Ban = row["ban"].ToString();
            this.SoKhach = (int)row["sokhach"];
            this.Gio = row["gio"].ToString();
            this.Ngay = row["ngay"].ToString();
            this.GhiChu = row["ghichu"].ToString();
        }
    }
}
