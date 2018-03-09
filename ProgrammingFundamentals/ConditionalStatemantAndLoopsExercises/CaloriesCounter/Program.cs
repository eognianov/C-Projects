using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string productName = "";
            int totalCalories = 0;
            for (int i =0;i<n;i++)
            {
                productName = Console.ReadLine().ToLower();
                switch(productName)
                {
                    case "cheese":
                        totalCalories += 500;
                        break;
                    case "tomato sauce":
                        totalCalories += 150;
                        break;
                    case "salami":
                        totalCalories += 600;
                        break;
                    case "pepper":
                        totalCalories += 50;
                        break;
                }
            }
            Console.WriteLine($"Total calories: {totalCalories}");
        }
    }
}
