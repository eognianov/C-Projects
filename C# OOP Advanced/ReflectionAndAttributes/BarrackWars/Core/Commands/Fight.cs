using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    class Fight:Command
    {
        public Fight(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
