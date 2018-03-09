using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;
using BashSoft.StaticData;

namespace BashSoft.IO.Commands
{
    class OpenFileCommand:Command
    {
        public OpenFileCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string fileName = this.Data[1];
                Process.Start(SessionData.currentPath + '\\' + fileName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
