using System;
using BashSoft.Contracts;
using BashSoft.StaticData;

namespace BashSoft.IO
{
    public class InputReader:IReader
    {
        private const string endCommand = "quit";
        private IIntrerpreter interpreter;

        public InputReader(IIntrerpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            string input = Console.ReadLine();
            input.Trim();

            while (input!=endCommand)
            {
                this.interpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine();
                input.Trim();
            }
        }
    }
}
