using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SinhVien
    {
        public string name { get; set; }
        [Key]
        public string msv { get; set; }
        public string tuoi { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public virtual ICollection<Love> Loves { get; set; }
    }

}
