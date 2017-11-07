using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniCoffeeOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal totalPrice = 0;
            for (int i = 0; i < n; i++)
            {
                decimal price = ReadOrderAndCalculatePrice();
                totalPrice += price;
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");
        }

        static decimal ReadOrderAndCalculatePrice()
        {
            decimal pricePerCapcule = decimal.Parse(Console.ReadLine());
            string dateUnparsed = Console.ReadLine();
            DateTime date = DateTime.ParseExact(dateUnparsed, "d/M/yyyy",null);
            decimal capsules = decimal.Parse(Console.ReadLine());
            decimal dayInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            decimal price = (dayInMonth * capsules) * pricePerCapcule;
            Console.WriteLine($"The price for the coffee is: ${price:F2}");
            return price;
        }
    }
}
