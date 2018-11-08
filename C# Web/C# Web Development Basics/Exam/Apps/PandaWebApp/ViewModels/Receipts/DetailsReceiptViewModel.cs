using System;
using System.Collections.Generic;
using System.Text;
using PandaWebApp.ViewModels.Packages;

namespace PandaWebApp.ViewModels.Receipts
{
    public class DetailsReceiptViewModel:ReceiptViewModel
    {
        public PackageDetailsViewModel Package { get; set; }
    }
}
