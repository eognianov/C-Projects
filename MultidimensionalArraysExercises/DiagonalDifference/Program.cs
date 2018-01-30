using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,n];
            for (int row = 0; row < n; row++)
            {
                int[] inputRow = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int column = 0; column < n; column++)
                {
                    matrix[row, column] = inputRow[column];
                }
            }
            int primaryDiagonal = 0, secondaryDiagonal = 0;
            for (int i = 0; i<n; i++)
            {
                primaryDiagonal += matrix[i, i];
                secondaryDiagonal += matrix[i, n - i -1];
            }
            Console.WriteLine(Math.Abs(primaryDiagonal-secondaryDiagonal));
        }

        
    }
}
