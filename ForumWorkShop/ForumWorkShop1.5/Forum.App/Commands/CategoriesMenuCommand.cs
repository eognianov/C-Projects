using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class CategoriesMenuCommand:NavigationCommnand
    {
        public CategoriesMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {
        }
    }
}
