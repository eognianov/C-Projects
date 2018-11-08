using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels.Packages
{
    public class ListOfPackagesViewModel
    {
        public IEnumerable<PackageDetailsViewModel> Packages { get; set; }
    }
}
