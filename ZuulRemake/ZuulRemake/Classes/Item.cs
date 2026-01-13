using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuulRemake.Classes
{
    internal class Item
    {
        // instance variables - replace the example below with your own
        public string description { get; set; }
        public int weight { get; set; }
        public string name { get; set; }

        /**
         * Constructor for objects of class Item
         */
        public Item(string name, string description, int weight)
        {
            this.name = name;
            this.description = description;
            this.weight = weight;
        }

        public string toString()
        {
            return "name: " + name + "\ndescription: " + description + "\nweight: " + weight;
        }

        
    }
}
