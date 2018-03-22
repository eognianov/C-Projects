using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorLogger.Models.Contracts
{
    interface ILogFile
    {
        string Path { get; }

        int Size { get; }

        void WriteToFile(string errorLog);
    }
}
