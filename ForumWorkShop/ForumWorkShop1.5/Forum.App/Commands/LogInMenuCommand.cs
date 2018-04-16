using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Commands
{
    class LogInMenuCommand:NavigationCommnand
    {
        public LogInMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {
        }
    }
}
