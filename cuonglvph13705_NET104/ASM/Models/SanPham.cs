using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace ASM.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        [StringLength(100)]
        public string MaSanPham { get; set; }
        [StringLength(100)]
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }

        public int GiaBan { get; set; }
        [StringLength(100)]
        public string Ghichu { get; set; }
      
        public bool TrangThai { get; set; }
        [DisplayName("Image Name")]
        public string ImgName { get; set; }
        [NotMapped]
        [DisplayName("UpLoad File")]
        public IFormFile ImgFile { get; set; }
        public string MaDanhMuc { get; set; }
        [ForeignKey("MaDanhMuc")]
        public DanhMuc danhMuc { get; set; }

    }
}
