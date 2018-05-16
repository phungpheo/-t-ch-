using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAHANG_RIENG.DTO
{
    public class Food
    {
        public Food(int id, string name, string catery, float gia)
        {
            this.ID = id;
            this.Name = name;
            this.LoaiMon = catery;
            this.Gia = gia;
        }

        public Food(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Name = row["NAME"].ToString();
            this.LoaiMon =row["CATERY"].ToString();
            this.Gia = (float)Convert.ToDouble(row["GIA"].ToString());
        }


        private float gia;
        private int iD;
        private string loaiMon;
        private string name;



        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string LoaiMon { get => loaiMon; set => loaiMon = value; }
        public float Gia { get => gia; set => gia = value; }
    }
}
