using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHAHANG_RIENG.DTO
{
    class Bill
    {
        public Bill(int id, DateTime? datacheckIn, DateTime? datacheckOut, int status, int giamgia = 0)
        {
            this.ID = id;
            this.DatecheckIn = datacheckIn;
            this.DatecheckOut = datacheckOut;
            this.Status = status;
            this.GiamGia = giamgia;
        }

        public Bill( DataRow row)
        {
            this.ID = (int)row["id"];
        
            this.DatecheckIn = (DateTime?)row["datecheckIn"];
            var datacheckOutTemp = row["dateCheckOut"];
            if (datacheckOutTemp.ToString() != "")
                this.DatecheckOut = (DateTime?)datacheckOutTemp;
            this.Status = (int)row["status"];
            if(row["giamGia"].ToString() != "") 
                this.GiamGia = (int)row["giamGia"];
        }

        private int iD;

        private DateTime? datecheckIn;

        private DateTime? datecheckOut;

        private int status;

        private int giamGia;

        public int ID { get => iD; set => iD = value; }

        public DateTime? DatecheckIn { get => datecheckIn; set => datecheckIn = value; }

        public DateTime? DatecheckOut { get => datecheckOut; set => datecheckOut = value; }

        public int Status { get => status; set => status = value; }

        public int GiamGia { get => giamGia; set => giamGia = value; }
    }
}
