using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeIngredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            int countIngredient = 0;
            while (inputLine != "Bake!")
            {
                Console.WriteLine($"Adding ingredient {inputLine}.");
                countIngredient++;
                inputLine = Console.ReadLine();
            }
            Console.WriteLine($"Preparing cake with {countIngredient} ingredients.");

        }
    }
}
