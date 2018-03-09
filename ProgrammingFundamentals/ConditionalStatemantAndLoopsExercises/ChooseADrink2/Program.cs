using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseADrink2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double bill = 0;
            switch (inputLine)
            {
                case "Athlete":
                    bill = quantity * 0.70;
                    break;
                case "Businessman":
                case "Businesswoman":
                    bill = quantity * 1.00;
                    break;
                case "SoftUni Student":
                    bill = quantity * 1.70;
                    break;
                default:
                    bill = quantity * 1.20;
                    break;
            }
            Console.WriteLine($"The {inputLine} has to pay {bill:F2}.");
        }
    }
}
