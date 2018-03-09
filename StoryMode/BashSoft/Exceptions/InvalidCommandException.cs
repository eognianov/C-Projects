using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Exceptions
{
    class InvalidCommandException:Exception
    {

        public InvalidCommandException(string input):base(string.Format("The command '{0}' is invalid", input))
        {
            
        }
    }
}
