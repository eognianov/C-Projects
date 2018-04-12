using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;
using BashSoft.StaticData;

namespace BashSoft.IO.Commands
{
    [Alias("open")]
    class OpenFileCommand:Command
    {
        public OpenFileCommand(string input, string[] data) : base(input, data)
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
