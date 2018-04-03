using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public abstract class Command:IExecutable
    {
        private string[] data;


        public Command(string[] data)
        {
            this.Data = data;
            
        }

        protected string[] Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        
        public abstract string Execute();

    }
}
