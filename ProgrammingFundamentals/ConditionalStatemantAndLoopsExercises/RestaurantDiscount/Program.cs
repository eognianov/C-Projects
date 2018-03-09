using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            double bill = 0;
            string hallName = "";
            if (groupSize >120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            if (groupSize<=50)
            {
                bill = 2500;
                hallName = "Small Hall";
            }
            else if(groupSize<=100)
            {
                bill = 5000;
                hallName = "Terrace";

            }
            else if(groupSize <= 120)
            {
                bill = 7500;
                hallName = "Great Hall";
            }
            switch(package)
            {
                case "Normal":
                    bill += 500;
                    bill -= bill * 5 / 100;
                    break;
                case "Gold":
                    bill += 750;
                    bill -= bill*10 / 100;
                    break;
                case "Platinum":
                    bill += 1000;
                    bill -= bill * 15 / 100;
                    break;
            }
            Console.WriteLine($"We can offer you the {hallName}"+Environment.NewLine+$"The price per person is { bill / groupSize:F2}$");
        }
    }
}
