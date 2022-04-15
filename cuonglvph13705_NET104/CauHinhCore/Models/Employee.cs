using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CauHinhCore.Models
{
    public class Employee
    {
        public string Employeecode { get; set; }
        public string name { get; set; }
        public DateTime dob { get; set; }
        public string address { get; set; }
        public string phonenumber { get; set; }
        public bool sex { get; set; }
        public string restaurantcode { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
