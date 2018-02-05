using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Func<int[], int> minNumber = n =>
            {
                int min = inputNumbers.OrderBy(x => x).First();
                return min;
            };
            Console.WriteLine(minNumber(inputNumbers));
        }
    }
}
