using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SalesReport
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sale> sales = new List<Sale>();
            sales = ReadSale();
            string[] towns = sales.Select(x => x.Town).Distinct().OrderBy(x => x).ToArray();
            foreach (var town in towns)
            {
                decimal totalSalesByTown =
                    sales.Where(x => x.Town == town).Distinct().Select(x => x.Price * x.Quantity).Sum();
                Console.WriteLine($"{town} -> {totalSalesByTown:F2}");
            }
        }

        static List<Sale> ReadSale()
        {
            List<Sale> sales = new List<Sale>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] saleInfo = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var sale = new Sale(){Town = saleInfo[0],Product = saleInfo[1],Price = decimal.Parse(saleInfo[2]),Quantity = decimal.Parse(saleInfo[3])};
                sales.Add(sale);
            }
            return sales;
        }

    public class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
    }
}
