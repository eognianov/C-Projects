using System;
using System.Linq;

namespace MaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = inputData[0];
            int columns = inputData[1];
            int[,] matrix = new int[rows,columns];
            for (int row = 0; row < rows; row++)
            {
                int[] inputRow = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int column = 0; column < columns; column++)
                {
                    matrix[row, column] = inputRow[column];
                }
            }

            Tuple<int, int> indexes = Tuple.Create(0, 0);
            int maxSum = 0;
            for (int row = 0; row < rows-2; row++)
            {
                for (int column = 0; column < columns-2; column++)
                {
                    int tempSum = matrix[row, column] + matrix[row, column + 1] + matrix[row, column + 2] +
                                  matrix[row + 1, column] + matrix[row + 1, column + 1] + matrix[row + 1, column + 2] +
                                  matrix[row + 2, column] + matrix[row + 2, column + 1] + matrix[row + 2, column + 2];
                    if (tempSum>maxSum)
                    {
                        maxSum = tempSum;
                        indexes = new Tuple<int, int>(row,column);
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = indexes.Item1; row < indexes.Item1+3; row++)
            {
                for (int column = indexes.Item2; column < indexes.Item2+3; column++)
                {
                    Console.Write(matrix[row,column] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
