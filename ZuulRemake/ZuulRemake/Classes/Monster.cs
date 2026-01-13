using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZuulRemake.Classes
{
    internal class Monster
    {
        // instance variables - replace the example below with your own

        public string name { get; set; }
        public int attack { get; set; }
        public int hp { get; set; }
        private Item? item { get; set; }
        /**
         * Constructor for objects of class monster
         */
        public Monster(string name, int hp)
        {
            this.name = name;
            this.hp = hp;
        }
        
        

        public string toString()
        {
            return "name: " + name + "\nAttack: " + attack + "\nHP: " + hp;
        }
        /**
         * determines if the monster is still alive
         */
        public bool isAlive()
        {
            return hp > 0;
        }

        public int gotAttacked()
        {
            if (isAlive())
            {
                hp -= 50;
            }
            return hp;
        }

        

        public void Attack(Player player)
        {
            if (isAlive())
            {
                player.GotHit();
            }
        }
    }
}
