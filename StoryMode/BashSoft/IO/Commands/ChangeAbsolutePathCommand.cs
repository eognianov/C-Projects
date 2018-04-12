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
    [Alias("cdabs")]
    class ChangeAbsolutePathCommand:Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeAbsolutePathCommand(string input, string[] data) : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string absolutePath = this.Data[1];
                this.inputOutputManager.ChangeDirectoryAbsolute(absolutePath);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
