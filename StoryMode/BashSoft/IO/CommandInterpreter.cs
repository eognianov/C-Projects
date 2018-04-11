using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
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
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "ls":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cdRel":
                    return new ChangeRelativePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cdAbs":
                    return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "readDb":
                    return new ReadDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "show":
                    return new ShowCourseCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "display":
                    return new DisplayCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                //case "decOrder":
                //    break;
                //case "download":
                //    break;
                //case "downloadAsynch":
                //    break;
                case "dropdb":
                    return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                default:
                    throw new InvalidCommandException(input);
                    
            }
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
