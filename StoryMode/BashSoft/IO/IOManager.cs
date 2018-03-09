using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using BashSoft.Exceptions;
using BashSoft.StaticData;

namespace BashSoft.IO
{
    public class IOManager
    {
        public void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIndentation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.currentPath);
            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int indentation = currentPath.Split('\\').Length - initialIndentation;
                if (depth - indentation < 0)
                {
                    break;
                }
                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', indentation), currentPath));
                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int indexOfSlash = file.LastIndexOf('\\');
                        string fileName = file.Substring(indexOfSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfSlash) + fileName);
                    }

                    foreach (string directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessException);
                }
                
            }
        }

        public void CreateDirectoryInCurrentFolder(string name)
        {
            string path = Directory.GetCurrentDirectory() + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (InvalidFileNameException)
            {
                throw new InvalidFileNameException();
                //throw new ArgumentException(ExceptionMessages.ForbiddenSymbolsContainedInName);
            }
            
        }

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf('\\');
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (InvalidPathException)
                {
                    throw new InvalidPathException();
                    //throw new ArgumentOutOfRangeException("indexOfLastSlash", ExceptionMessages.InvalidPath);
                    //OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }
                
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += '\\' + relativePath;
                ChangeDirectoryAbsolute(currentPath);
            }
        }

        public void ChangeDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                throw new InvalidPathException();
                //throw new DirectoryNotFoundException(ExceptionMessages.InvalidPath);

                //OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                //return;
            }
            SessionData.currentPath = absolutePath;
        }
    }
}
