using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class AddGioHang
    {
        public GioHang gioHang { get; set; }
        public GioHang_ChiTiet gioHang_ChiTiet { get; set; }
        public SanPham sanPham { get; set; }
    }
}
