using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM.Models
{
    [Table("DoanhMuc")]
    public class DanhMuc
    {
        [Key]
        [StringLength(100)]
        public string MaDoanhMuc { get; set; }
        [StringLength(100)]
        public string TenDoanhMuc { get; set; }
        [StringLength(100)]
        public string GhiChu { get; set; }
        public bool TrangThai { get; set; }
    }
}
