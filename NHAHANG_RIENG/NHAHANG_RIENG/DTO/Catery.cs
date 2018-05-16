using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NHAHANG_RIENG.DTO
{
    public class Catery
    {
        public Catery(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public Catery(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
        }
        private string name;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
    }
}


