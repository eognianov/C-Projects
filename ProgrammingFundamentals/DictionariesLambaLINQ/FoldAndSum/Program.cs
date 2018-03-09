using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = inputNumbers.Length / 4;
            int[] firstRowLeft = inputNumbers.Take(k).Reverse().ToArray();
            int[] firstRowRight = inputNumbers.Skip(3 * k).Take(k).Reverse().ToArray();
            int[] firstRow = firstRowLeft.Concat(firstRowRight).ToArray();
            int[] secondRow = inputNumbers.Skip(k).Take(2 * k).ToArray();
            for (int i = 0; i < 2*k; i++)
            {
                Console.Write($"{firstRow[i]+secondRow[i]} ");
            }
            Console.WriteLine();
        }
    }
}
