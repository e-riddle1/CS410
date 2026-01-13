using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZuulRemake.Classes
{
    internal class CommandWord
    {

        // A value for each command word along with its
        // corresponding user interface string.
        public static readonly CommandWord GO = new CommandWord("go");
        public static readonly CommandWord HELP = new CommandWord("help");
        public static readonly CommandWord UNKNOWN = new CommandWord("?");
        public static readonly CommandWord LOOK = new CommandWord("look");
        public static readonly CommandWord TAKE = new CommandWord("take");
        public static readonly CommandWord INVENTORY = new CommandWord("inventory");
        public static readonly CommandWord BACK = new CommandWord("back");
        public static readonly CommandWord DROP = new CommandWord("drop");
        public static readonly CommandWord USE = new CommandWord("use");
        public static readonly CommandWord ATTACK = new CommandWord("attack");



       
      



        // The command string.
        private string commandString;

       
        CommandWord(string commandString)
        {
            this.commandString = commandString;
        }

        /**
         * @return The command word as a string.
         */
        public string toString()
        {
            return commandString;
        }
      }
    }
