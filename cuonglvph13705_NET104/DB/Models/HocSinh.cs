using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Models
{
    public partial class HocSinh
    {
        public string Msv { get; set; }
        public string Ten { get; set; }
        public DateTime Dob { get; set; }
        public string Diachi { get; set; }
        public bool? Gioitinh { get; set; }
        public string Sdt { get; set; }
    }
}
