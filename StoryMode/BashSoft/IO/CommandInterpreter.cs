using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using BashSoft.Attributes;
using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.IO.Commands;
using BashSoft.Judge;
using BashSoft.Repository;
//using BashSoft.Data;
using BashSoft.StaticData;

namespace BashSoft.IO
{
    public class CommandInterpreter:IIntrerpreter
    {
        private IConterComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IConterComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];

            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            object[] parametersForConstruction = new object[]
            {
                input, data
            };

            //Type typeOfCommand = Assembly.GetExecutingAssembly().GetTypes().First(type =>
            //type.GetCustomAttributes(typeof(AliasAttribute)).Where(atr => atr.Equals(command)).ToArray().Length >
            //0);

            Type typeOfCommand = Assembly.GetExecutingAssembly().GetTypes().First(t => t.GetCustomAttributes(typeof(AliasAttribute)).Where(a => a.Equals(command)).ToArray().Length > 0);

            Type typeOfInterpreter = typeof(CommandInterpreter);

            Command exe = (Command) Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] fieldsOfInterpreter =
                typeOfInterpreter.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atrAttribute = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));
                if (atrAttribute!=null)
                {
                    if (fieldsOfInterpreter.Any(x=>x.FieldType==fieldOfCommand.FieldType))
                    {
                        fieldOfCommand.SetValue(exe, fieldsOfInterpreter.First(x=>x.FieldType==fieldOfCommand.FieldType).GetValue(this));
                    }
                }
            }

            return exe;
        }

        private void DownloadFile(string input, string[] data)
        {
            try
            {
                if (data.Length == 2)
                {
                    var remoteAddress = data[1];
                    var fileName = Path.GetFileName(remoteAddress);
                    var myWebClient = new WebClient();
                    myWebClient.DownloadFile(remoteAddress, fileName);
                    var path = AppDomain.CurrentDomain.BaseDirectory;
                    OutputWriter.WriteMessageOnNewLine($"The file was downloaded here: {path}");
                }
                else
                {
                    throw new InvalidCommandException(input);
                }
            }
            catch (WebException)
            {
                //OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsInUrl);
            }
        }

        private void DownloadFileAsynch(string input, string[] data)
        {
            try
            {
                if (data.Length == 2)
                {
                    var fileName = Path.GetFileName(data[1]);
                    var uri = new Uri(data[1]);
                    var myWebClient = new WebClient();
                    myWebClient.DownloadFileAsync(uri, fileName);
                    var path = AppDomain.CurrentDomain.BaseDirectory;
                    OutputWriter.WriteMessageOnNewLine($"The file is downloading here: {path}");
                }
                else
                {
                    throw new InvalidCommandException(input);
                }
            }
            catch (WebException)
            {
                //OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsInUrl);
            }
        }

    }
}
