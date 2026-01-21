using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZuulRemake.Classes
{
    internal class Player(string name)
    {
        // instance variables - replace the example below with your own
        private readonly string name = name;
        private Room currentRoom;
        private readonly BackPack backpack = new BackPack();
        private readonly int maximumWeight = 2;
        private readonly Stack<Room> previousRoom = new Stack<Room>();
        private Room? chargeRoom;
        private int hp = 100;

        public string ExitsAvailable()
        {
            string returnString = "";
            returnString += currentRoom.GetExitString();
            return returnString;
        }

        /**
         * returns the current room that you are in.
         */
        public Room GetCurrentRoom()
        {
            return currentRoom;
        }

        /**
         * takes item out of room and places it into the backpack as long as
         * you can carry it.
         */
        public bool AddToBackPack(Item item)
        {
            if (CanCarry(item))
            {
                currentRoom.RemoveItem(item.Name);
                backpack.AddItem(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
         * this returns the current room that you are in.
         */
        public string EnterRoom(Room nextRoom)
        {
            string returnString = "";
            currentRoom = nextRoom;

            returnString += currentRoom.ToString();
            return returnString;
        }

        /**
         * if the next room isnt empty or locked it takes you to the next room using
         * commandword go and the direction you want to go to depending on the 
         * given exits. then it pushes the room in the stack.
         */
        public string GoNewRoom(string direction)
        {
            if (!currentRoom.TryGetExit(direction, out Room nextRoom)) return "there is no door (or it is locked).";
            // Try to leave current room.
            previousRoom.Push(currentRoom);
            currentRoom = nextRoom;
            return currentRoom.ToString();
           
        }

        /**
         * checks player inventory for key
         
        public bool checkForKey()
        {
            return backpack.keyCheck();
        }
        **/
        /**
         * displays the toString from the room class.
         */
        public string GetRoomDescription()
        {
            return currentRoom.ToString();
        }

        /**
         * if the player is able to add the item to the backpack then the player
         * will take the item. if not the game will tell the player it is too
         * heavy.
         */
        public string TakeItem(string name)
        {
            string returnString = "";
            Item item = currentRoom.GetItem(name);
            if (item == null)
            {
                returnString += "that item isnt in the room";
            }
            else
            {
                if (AddToBackPack(item))
                {
                    returnString += "took: " + item.ToString();
                }
                else
                {
                    returnString += name + " is too heavy to carry";
                }
            }
            return returnString;
        }

        /**
         * checks to see if the item is in the backpack, if the backpack is
         * empty, it will tell you, otherwise it will remove the item from
         * the backpack and add it to the room.
         */
        public string DropItem(string name)
        {
            string returnString = "";
            Item itemRemove = GetItemFromBackpack(name);

            if (itemRemove == null)
            {
                returnString += "this item isnt in your backpack";
            }
            else
            {
                RemoveFromBackpack(name);
                currentRoom.SetItem(name, itemRemove);
                returnString += name + " dropped";
            }
            return returnString;
        }

        /**
         * removes the item from the backpack.
         */
        public void RemoveFromBackpack(string itemRemove)
        {
            backpack.RemoveItem(itemRemove);
        }

        /**
         * returns an item from the backpack if it is available.
         */
        public Item GetItemFromBackpack(string item)
        {
            return backpack.GetItem(item);
        }

        /**
         * displays player hp
         */
        public int GetHp()
        {
            return hp;
        }
        //public void setCurrentRoom(Room newRoom)
        //{
        //    previousRoom.push(currentRoom);
        //    currentRoom = newRoom;
        //}

        /**
         * takes the player back one room using the stack utilit. if there
         * is no previous room it will tell you that you cant go back.
         * 
         */
        public string GoBack()
        {
            string returnString = "";

            if (previousRoom == null)
            {
                returnString += "There is no turning back!";
            }
            else
            {
                Room lastRoom = previousRoom.Pop();
                EnterRoom(lastRoom);
                returnString += currentRoom.ToString();
            }
            return returnString;
        }
        //public string getCookie()
        //{

        //}
        /**
         * if the weight of the backpack is less than the maximum weight
         * and the item is less than the remaining weight available
         * then the player can pick up the item. if not the player is unable
         * to.
         */
        private bool CanCarry(Item item)
        {
            bool canCarry = true;
            int totalWeight = backpack.GetTotalWeight() + item.Weight;
            if (totalWeight > maximumWeight)
            {
                canCarry = false;
            }
            return canCarry;
        }

        public void EquipItem()
        {
            string returnString = "";
            hp += 101;
            returnString += hp;
        }

        /**
         * determines if the player got hit
         */
        public int GotHit()
        {
            if (currentRoom.GetMonster(name).isAlive())
            {
                return hp -= 100;
            }
            return GotHit();
        }

        public string attack(string name)
        {
            string returnString = "";
            Monster monster = currentRoom.GetMonster(name);
            if (monster == null)
            {
                returnString += "that monster is no monster in this room";
            }
            else if (GetInventoryString().Contains("sword"))
            {
                hp -= 100;
                returnString += "\nyou attacked the monster" + "\nmonster HP: " + monster.Hp;
                returnString += "\nthe monster hit you back";
                monster.gotAttacked();
                returnString += "\n" + "your HP: " + hp;
            }
            else
            {
                returnString += " you dont have anything to attack" + name + "with";
            }

            return returnString;
        }

        /**
         * checks to see if there are any turns left. if there arent then it
         * is game over.
         */
        public bool gameOver()
        {
            return hp == 0;
        }

        /**
         * returns items displayed in the inventory
         */
        public string GetInventoryString()
        {
            int totalWeight = backpack.GetTotalWeight();
            return backpack.InventoryToString() + "\nweight: " + totalWeight + "/" + maximumWeight + "\nHP:" + hp;
        }

        /**
         * charges the beamer to memorize the current room
         */
        public string BeamerCharge()
        {
            string returnstring = "";
            chargeRoom = currentRoom;
            returnstring += "charged beamer";
            return returnstring;
        }

        /**
         * fires the beamer to take you to the charge room
         */
        public string BeamerFire()
        {
            string returnstring = "";
            if (chargeRoom != null)
            {
                EnterRoom(chargeRoom);
                returnstring += "fired beamer:" + "\n" + GetRoomDescription();
            }
            else
            {
                returnstring += "you have to charge the beamer first";
            }
            return returnstring;
        }
    }
}
