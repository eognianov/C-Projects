using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Contracts
{
    public interface IConterComparer
    {
        void CompareContent(string userOutputPath, string expectedOutputPath);
    }
}
