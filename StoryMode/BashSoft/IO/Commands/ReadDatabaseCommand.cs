using System;
using System.Collections.Generic;
using System.Text;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    [Alias("readDb")]
    class ReadDatabaseCommand:Command
    {
        [Inject] private IDatabase repository;
        public ReadDatabaseCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string fileName = this.Data[1];
                this.repository.LoadData(fileName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }

        }
    }
}
