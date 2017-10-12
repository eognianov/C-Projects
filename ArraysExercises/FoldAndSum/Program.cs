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
            var intputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = intputNumbers.Length / 4;
            int j = 0;
            int[] tempArr = new int[k];
            int[] firstRow = new int[intputNumbers.Length/2];
            int[] secondRow = new int[intputNumbers.Length/2];
            for (int i = 0; i < 2*k; i++)
            {
                secondRow[i] = intputNumbers[i + k];
            }
            for (int i = k-1; i >= 0; i--)
            {
                firstRow[j] = intputNumbers[i];
                j++;
            }
            for (int i = intputNumbers.Length-1; i >= 3*k; i--)
            {
                firstRow[j] = intputNumbers[i];
                j++;
            }
            for (int i = 0; i < firstRow.Length; i++)
            {
                Console.Write($"{firstRow[i]+secondRow[i]} ");
            }
            Console.WriteLine();
        }
    }
}
