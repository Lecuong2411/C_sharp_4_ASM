using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_3.Models
{
    public class Cntt
    {
        private string name;
        private string image;

        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }

        public Cntt(string name, string image)
        {
            this.name = name;
            this.image = image;
        }

        public Cntt()
        {
        }
    }
}
