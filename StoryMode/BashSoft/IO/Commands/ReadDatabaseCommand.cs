using System;
using System.Collections.Generic;
using System.Text;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    class ReadDatabaseCommand:Command
    {
        public ReadDatabaseCommand(string input, string[] data, IConterComparer judge, IDatabase repository, IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string fileName = this.Data[1];
                this.Repository.LoadData(fileName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }

        }
    }
}
