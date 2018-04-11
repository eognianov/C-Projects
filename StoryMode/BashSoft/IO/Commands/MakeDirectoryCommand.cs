using System;
using System.Collections.Generic;
using System.Text;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    class MakeDirectoryCommand:Command
    {
        public MakeDirectoryCommand(string input, string[] data, IConterComparer judge, IDatabase repository, IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string folderName = this.Data[1];
                this.InputOutputManager.CreateDirectoryInCurrentFolder(folderName);

            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
