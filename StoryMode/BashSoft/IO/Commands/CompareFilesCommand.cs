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
    [Alias("cmp")]
    class CompareFilesCommand:Command
    {
        [Inject] private IConterComparer judge;

        public CompareFilesCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 3)
            {
                string firstPath = this.Data[1];
                string secondPath = this.Data[2];

                this.judge.CompareContent(firstPath, secondPath);
            }
            else

            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
