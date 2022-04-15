using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_4.Models
{
    public class nhieusinhvien
    {
        public List<sinhviens> sinhviens;

        public nhieusinhvien(List<sinhviens> sinhviens)
        {
            this.Sinhviens = sinhviens;
        }

        public List<sinhviens> Sinhviens { get => sinhviens; set => sinhviens = value; }
    }
}
