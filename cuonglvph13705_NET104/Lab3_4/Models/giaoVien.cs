using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_4.Models
{
    public class giaoVien
    {
        string name;
        string msv;
        int tuoi = 19;
        int solop;
        string bomon;

        public giaoVien(string name, string msv, int tuoi, int solop, string bomon)
        {
            this.name = name;
            this.msv = msv;
            this.tuoi = tuoi;
            this.solop = solop;
            this.bomon = bomon;
        }

        public string Name { get => name; set => name = value; }
        public string Msv { get => msv; set => msv = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public int Solop { get => solop; set => solop = value; }
        public string Bomon { get => bomon; set => bomon = value; }
    }
}
