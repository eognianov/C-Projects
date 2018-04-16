using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Commands
{
    class SignUpMenuCommand:NavigationCommnand
    {
        public SignUpMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {
        }
    }
}
