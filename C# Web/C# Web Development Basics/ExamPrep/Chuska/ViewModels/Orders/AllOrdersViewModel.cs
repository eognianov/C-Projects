using System.Collections.Generic;

namespace Chuska.ViewModels.Orders
{
    public class AllOrdersViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}