using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Exceptions
{
    class InvalidPathException:Exception
    {
        public const string InvalidPath =
            "The source does not exist.";

        public InvalidPathException():base(InvalidPath)
        {
            
        }

        public InvalidPathException(string message):base(message)
        {
            
        }
    }
}
