using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using BashSoft.Judge;
using BashSoft.Repository;
//using BashSoft.Data;
using BashSoft.StaticData;

namespace BashSoft.IO
{
    public  class CommandInterpreter
    {
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;

        public CommandInterpreter(Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }
        public  void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string command = data[0];
            
            switch (command)
            {
                case "open":
                    TryOpenFile(input, data);
                    break;
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;
                case "ls":
                    TryTreverseFolders(input, data);
                    break;
                case "cmp":
                    TryCompareFiles(input, data);
                    break;
                case "cdRel":
                    TryChangePathRelatively(input, data);
                    break;
                case "cdAbs":
                    TryChangePathAbsolute(input, data);
                    break;
                case "readDb":
                    TryReadDatabaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                case "show":
                    TryShowWantedData(input, data);
                    break;
                case "filter":
                    TryFilterAndTake(input, data);
                    break;
                case "order":
                    TryOrderAndTake(input, data);
                    break;
                case "decOrder":
                    break;
                case "download":
                    break;
                case "downloadAsynch":
                    break;
                case "dropdb":
                    TryDropDb(input, data);
                    break;
                default:
                    DisplaInvalidCommandMessage(input);
                    break;
            }
        }

        private  void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                DisplaInvalidCommandMessage(input);
            }
        }

        private  void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    this.repository.OrderAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.repository.OrderAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }

        private  void TryFilterAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                DisplaInvalidCommandMessage(input);
            }
        }

        private  void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity=="all")
                {
                    this.repository.FilterAndTake(courseName,filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        this.repository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }   
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
            }
        }

        private  void TryShowWantedData(string input, string[] data)
        {
            if (data.Length==2)
            {
                string courseName = data[1];
                this.repository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length==3)
            {
                string courseName = data[1];
                string userName = data[2];
                this.repository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                DisplaInvalidCommandMessage(input);
            }
        }

        private  void TryGetHelp(string input, string[] data)
        {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl:relative path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir:absolute path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }

        private  void TryReadDatabaseFromFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                this.repository.LoadData(fileName);
            }
            else
            {
                DisplaInvalidCommandMessage(input);
            }
        }

        private  void TryChangePathAbsolute(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string absolutePath = data[1];
                this.inputOutputManager.ChangeDirectoryAbsolute(absolutePath);
            }
            else
            {
                DisplaInvalidCommandMessage(input);
            }
        }

        private  void TryChangePathRelatively(string input, string[] data)
        {

            if (data.Length == 2)
            {
                string relPath = data[1];
                this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                DisplaInvalidCommandMessage(input);

            }
        }

        private  void TryCompareFiles(string input, string[] data)
        {
            if (data.Length==3)
            {
                string firstPath = data[1];
                string secondPath = data[2];

                this.judge.CompareContent(firstPath,secondPath);
            }
            else
            {
                DisplaInvalidCommandMessage(input);
            }

        }

        private  void DisplaInvalidCommandMessage(string input)
        {

            OutputWriter.DisplayException($"The command '{input}' is invalid");
        }

        private  void TryTreverseFolders(string input, string[] data)
        {
            if (data.Length == 1)
            {
                this.inputOutputManager.TraverseDirectory(0);
            }
            else if (data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(data[1], out depth);
                if (hasParsed)
                {
                    this.inputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                }
            }
            else
            {
                DisplaInvalidCommandMessage(input);
            }
        }

        private  void TryCreateDirectory(string input, string[] data)
        {

            if (data.Length == 2)
            {
                string folderName = data[1];
                this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
                
            }
            else
            {
                DisplaInvalidCommandMessage(input);
            }
        }

        private  void TryOpenFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                Process.Start(SessionData.currentPath + '\\' + fileName);
            }
            else
            {
                DisplaInvalidCommandMessage(input);
            }
        }

        private  void DownloadFile(string input, string[] data)
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
                    DisplaInvalidCommandMessage(input);
                }
            }
            catch (WebException)
            {
                //OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsInUrl);
            }
        }

        private  void DownloadFileAsynch(string input, string[] data)
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
                    DisplaInvalidCommandMessage(input);
                }
            }
            catch (WebException)
            {
                //OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsInUrl);
            }
        }

        private void TryDropDb(string input, string[] data)
        {
            if (data.Length !=1)
            {
                this.DisplaInvalidCommandMessage(input);
                return;
            }
            this.repository.UnloadDate();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}
