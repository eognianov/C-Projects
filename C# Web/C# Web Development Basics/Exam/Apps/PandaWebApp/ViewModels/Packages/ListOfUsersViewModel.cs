using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels.Packages
{
    public class ListOfUsersViewModel
    {
        public IEnumerable<CreatePackageUserViewModel> Users { get; set; }
    }
}
