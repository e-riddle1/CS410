using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuulRemake.Classes
{
    internal class Item(string name, string description, int weight)
    {
        // instance variables - replace the example below with your own
        public string Description { get; set; } = description;
        public int Weight { get; set; } = weight;
        public string Name { get; set; } = name;

        override
            public string ToString()
        {
            return "name: " + Name + "\ndescription: " + Description + "\nweight: " + Weight;
        }

        
    }
}
