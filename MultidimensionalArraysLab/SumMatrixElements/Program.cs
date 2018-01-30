using System;
using System.Collections.Generic;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> results = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int sum = 0;
            int rows = results[0];
            int columns = results[1];
            int[,] matrix = new int[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                int[] inputRow = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int column = 0; column < columns; column++)
                {
                    matrix[row, column] = inputRow[column];
                    sum += inputRow[column];
                }
            }
            results.Add(sum);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
        
    }
}
