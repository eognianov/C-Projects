using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNegativeAndReverse
{
    class Program
    {
        static void Main()
        {
            string inputLine = Console.ReadLine();
            List<int> numbers = inputLine.Split(' ').Select(int.Parse).ToList();
            List<int> results = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > 0)
                {
                    results.Add(numbers[i]);
                }
            }
            if (results.Count != 0)
            {
                results.Reverse();
                Console.WriteLine(string.Join(" ",results));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
