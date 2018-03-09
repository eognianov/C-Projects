using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumMinMaxAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] inputNumbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                inputNumbers[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Sum = {inputNumbers.Sum()}");
            Console.WriteLine($"Min = {inputNumbers.Min()}");
            Console.WriteLine($"Max = {inputNumbers.Max()}");
            Console.WriteLine($"Average = {inputNumbers.Average()}");
        }
    }
}
