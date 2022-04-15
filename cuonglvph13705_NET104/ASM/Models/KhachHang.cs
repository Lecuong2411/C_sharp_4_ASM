using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        [StringLength(100)]
        public string MaKhachHang { get; set; }
        [StringLength(100)]
        public string TenKhachHang { get; set; }
        [StringLength(10)]
        public string Sdt { get; set; }
        [StringLength(100)]
        public string DiaChi { get; set; }
    }
}
