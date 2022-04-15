using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai_tap_bo_sung.Models
{
    public class lstSv
    {
        private List<SinhVien> lstSinhvien;

        public lstSv(List<SinhVien> lstSinhvien)
        {
            this.lstSinhvien = lstSinhvien;
        }

        public List<SinhVien> LstSinhvien { get => lstSinhvien; set => lstSinhvien = value; }
    }
}
