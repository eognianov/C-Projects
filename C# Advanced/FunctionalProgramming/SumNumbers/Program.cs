using System;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Console.WriteLine(inputNumbers.Length);
            Console.WriteLine(inputNumbers.Sum());
        }
    }
}
