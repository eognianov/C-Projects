using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft
{
    public static class InputReader
    {
        private const string endCommand = "quit";
        public static void StarReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            string input = Console.ReadLine();
            input.Trim();

            while (input!=endCommand)
            {
                CommandInterpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine();
                input.Trim();
            }
        }
    }
}
