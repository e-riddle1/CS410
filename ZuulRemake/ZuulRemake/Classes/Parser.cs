using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuulRemake.Classes
{
    internal class Parser
    {
        private CommandWords commands;  // holds all valid command words
        
        /**
         * Create a parser to read from the terminal window.
         */
        public Parser()
        {
            commands = new CommandWords();
        }

        /**
         * @return The next command from the user.
         */
        public Command getCommand()
        {
            string inputLine;   // will hold the full input line
            string word1 = null;
            string word2 = null;

            Console.Write("> ");     // print prompt

            inputLine = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(inputLine)) {
                string[] words = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            // Now check whether this word is known. If so, create a command
            // with it. If not, create a "null" command (for unknown command).
            return new Command(commands.getCommandWord(word1), word2);
            }
    /**
     * print out a list of valid command words.
     */
    public void showCommands()
        {
            commands.showAll();
        }
    }
}
