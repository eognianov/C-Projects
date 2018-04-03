using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    class Retire:Command
    {
        [Inject]
        private IRepository repository;

        public Retire(string[] data, IRepository repository) : base(data)
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
            string unitType = Data[1];
            try
            {
                this.Repository.RemoveUnit(unitType);
                return $"{unitType} retired!";
            }
            catch (Exception e)
            {
                throw new ArgumentException("No such units in repository.", e);
            }
            
        }
    }
}
