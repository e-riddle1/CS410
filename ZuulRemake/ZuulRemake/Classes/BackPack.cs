using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZuulRemake.Classes
{
    internal class BackPack
    {
        // instance variables - replace the example below with your own
        private Dictionary<string, Item> inventory;

        /**
         * Constructor for objects of class Inventory
         */
        public  BackPack()
        {
            inventory = new Dictionary<string, Item>();
        }
        /**
         * adds an item to the inventory
         */
        public void AddItem(Item itemAdded)
        {
            inventory.Add(itemAdded.Name, itemAdded);
        }
        /**
         * removes an item from the hashmap.
         */
        public void RemoveItem(string name)
        {
            inventory.Remove(name);
        }
        /**
         * pulls an item out of the inventory.
         */
        public Item GetItem(string itemGet)
        {
            return inventory.Add(string, itemGet);
        }
        /**
         * checks for the room key in the inventory
         */
        public bool keyCheck()
        {

            return inventory.ContainsKey("key");
        }
        /**
         * displays all of the items in the inventory
         */
        public string inventoryToString()

        {
            string returnString = "";
            HashSet<string> keys = inventory.Keys;
            foreach (string item in keys)
            {
                returnString += " " + item;
            }
            if (returnString == (""))
            {
                returnString = "backpack is empty";
            }
            return returnString;
        }
        /**
         * adds an item to the inventory hashmap by name and item
         */
        public void add(string name, Item item)
        {
            inventory.Add(name, item);
        }
        /**
         * iterates on the weight of the items in the inventory.
         */
        public int getTotalWeight()
        {
            int weight = 0;
            for (Iterator<Item> iter = inventory.values().iterator(); iter.hasNext();)
            {
                weight += iter.next().getWeight();
            }
            return weight;
        }
    }
}
