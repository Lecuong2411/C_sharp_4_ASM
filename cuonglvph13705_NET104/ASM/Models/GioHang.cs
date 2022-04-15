using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.Models
{
    [Table("GioHang")]
    public class GioHang
    {
       [Key]
       [StringLength(100)]
        public string MaGioHang { get; set; }
        public string MaKhachHang { get; set; }
        [ForeignKey("MaKhachHang")]
        public KhachHang khachHang { get; set; }
        public DateTime ThoiGian { get; set; }
        public int TongTien { get; set; }
        [StringLength(100)]
        public string GhiChu { get; set; }
        public bool TrangThaiHD { get; set; }
    }
}
