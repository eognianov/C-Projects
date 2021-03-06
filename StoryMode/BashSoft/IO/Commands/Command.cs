﻿using System;
using System.Collections.Generic;
using System.Text;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.Judge;
using BashSoft.Repository;

namespace BashSoft.IO.Commands
{
    public abstract class Command:IExecutable
    {
        private string input;
        private string[] data;

        public Command(string input, string[] data)
        {
            this.Input = input;
            this.Data = data;
        }

        protected string Input
        {
            get
            {
                return this.input;

            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        protected string[] Data
        {
            get
            {
                return this.data; 

            }

            private set
            {
                if (value==null || value.Length==0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        public abstract void Execute();
    }
}
