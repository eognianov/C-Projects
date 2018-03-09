using System;
using System.Linq;

namespace GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var sizes = new int[3];
            foreach (var number in inputNumbers)
            {
                sizes[Math.Abs(number % 3)] ++;
            }
            int[][] jaggedArray = new int[3][];
            for (int counter = 0; counter < sizes.Length; counter++)
            {
                jaggedArray[counter] = new int[sizes[counter]];
            }
            int[] nextIndex = new int[3]{0,0,0};
            foreach (var number in inputNumbers)
            {
                int reminder = Math.Abs(number % 3);
                jaggedArray[reminder][nextIndex[reminder]] = number;
                nextIndex[reminder]++;
            }
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < sizes[row]; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
