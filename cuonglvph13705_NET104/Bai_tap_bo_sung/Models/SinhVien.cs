using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai_tap_bo_sung.Models
{
    public class SinhVien
    {
        string id;
        string name;
        int tuoi;
        double diem;

        public SinhVien(string id, string name, int tuoi, double diem)
        {
            this.id = id;
            this.name = name;
            this.tuoi = tuoi;
            this.diem = diem;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public double Diem { get => diem; set => diem = value; }
    }
}
