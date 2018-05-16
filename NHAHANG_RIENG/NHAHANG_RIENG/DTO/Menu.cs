using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAHANG_RIENG.DTO
{
    public class Menu
    {
        public Menu(string foodName, int count, float gia, float tongTien =0)
        {
            this.FoodName = foodName;
            this.Count = count;
            this.Gia = gia;
            this.TongTien = tongTien;
        }


        public Menu(DataRow row)
        {
            this.FoodName = row["Tên"].ToString();
            this.Count = (int)row["Số lượng"];
            this.Gia = (float)Convert.ToDouble(row["Giá"].ToString());
            this.TongTien = (float)Convert.ToDouble(row["Thành tiền"].ToString());
        }

        private float tongTien;
        private float gia;
        private int count;
        private string foodName;

        public string FoodName { get => foodName; set => foodName = value; }
        public float Gia { get => gia; set => gia = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
        public int Count { get => count; set => count = value; }
        public static object Instance { get; internal set; }
    }
}
