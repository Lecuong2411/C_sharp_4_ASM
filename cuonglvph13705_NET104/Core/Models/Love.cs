using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Love
    {
        public string TenLove { get; set; }
        [Key]
        public string MaLove { get; set; }
        public string   GVCN { get; set; }
        public string   Siso { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
