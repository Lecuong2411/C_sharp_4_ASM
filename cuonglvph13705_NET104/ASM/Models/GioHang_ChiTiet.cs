using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    [Table("GioHangChiTiet")]
    public class GioHang_ChiTiet
    {
        [Key, Column(Order = 1)]
        [StringLength(100)]
        public string MaGioHang { get; set; }
        [ForeignKey("MaGioHang")]
        public virtual GioHang GioHang { get; set; }
        [Key, Column(Order = 2)]
        [Required]
        public string MaSanPham { get; set; }
        [ForeignKey("MaSanPham")]
        public virtual SanPham SanPham { get; set; }

        public int? DonGia { get; set; }

        public int? Thanhtien { get; set; }
        public int? soluong { get; set; }
        public bool? TrangThai { get; set; }
    }
}
