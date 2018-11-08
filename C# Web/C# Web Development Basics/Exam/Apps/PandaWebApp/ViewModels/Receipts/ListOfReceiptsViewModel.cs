using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels.Receipts
{
    public class ListOfReceiptsViewModel
    {
        public IEnumerable<ReceiptViewModel> Receipts { get; set; }
    }
}
