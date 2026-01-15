using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZuulRemake.Classes
{
    internal class CommandWords
    {
        // A mapping between a command word and the CommandWord
        // associated with it.
        private Dictionary<string, CommandWord> validCommands;

        /**
         * Constructor - initialise the command words.
         */
        public CommandWords()
        {
            
            for (CommandWord command in  CommandWord.values())
            {
                if (command != CommandWord.UNKNOWN)
                {
                    validCommands.Add(command.ToString(), command);
                }
            }
        }

        /**
         * Find the CommandWord associated with a command word.
         * @param commandWord The word to look up.
         * @return The CommandWord correspondng to commandWord, or UNKNOWN
         *         if it is not a valid command word.
         */
        public CommandWord GetCommandWord(string commandWord)
        {
            CommandWord command = validCommands.get(commandWord);
            if (command != null)
            {
                return command;
            }
            else
            {
                return CommandWord.UNKNOWN;
            }
        }

        /**
         * Check whether a given String is a valid command word. 
         * @return true if it is, false if it isn't.
         */
        public bool isCommand(string aString)
        {
            return validCommands.ContainsKey(aString);
        }

        /**
         * Print all valid commands to System.out.
         */
        public void showAll()
        {
            foreach (string command in validCommands.KeySet())
            {
                Console.Write(command + "  ");
            
        }
    }
}
