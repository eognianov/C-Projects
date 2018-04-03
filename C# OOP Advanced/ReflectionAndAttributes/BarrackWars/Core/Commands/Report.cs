using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    class Report:Command
    {
        [Inject]
        private IRepository repository;

        public Report(string[] data, IRepository repository) : base(data)
        {
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }

        

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
