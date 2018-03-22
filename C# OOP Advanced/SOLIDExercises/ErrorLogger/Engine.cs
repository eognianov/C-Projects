using System;
using System.Collections.Generic;
using System.Text;
using ErrorLogger.Models.Contracts;
using ErrorLogger.Models.Factories;

namespace ErrorLogger
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine())!="END")
            {
                string[] errorArgs = input.Split('|');
                string errorLevel = errorArgs[0];
                string errorDateTime = errorArgs[1];
                string errorMessage = errorArgs[2];

                IError error = errorFactory.CreatError(errorDateTime, errorLevel, errorMessage);
                this.logger.Log(error);
            }

            Console.WriteLine("Logger info");
            foreach (IAppender appender in this.logger.Appenders)
            {

                Console.WriteLine(appender);
            }
        }
    }
}
