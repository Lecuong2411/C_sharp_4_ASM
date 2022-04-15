using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CauHinhCore.Models
{
    public class Restaurant
    {
        public string name { get; set; }
        public string address { get; set; }
        public string sdt { get; set; }
        public string rate { get; set; }
        public string restaurantcode { get; set; }
        public ICollection<Employee> Employee { get; set; }

    }
}
