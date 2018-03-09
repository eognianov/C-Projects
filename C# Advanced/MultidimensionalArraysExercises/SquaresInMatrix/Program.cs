using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = inputData[0];
            int columns = inputData[1];
            char[,] matrix = new char[rows,columns];
            int result = 0;
            for (int row = 0; row < rows; row++)
            {
                char[] inputRow = Trim(Console.ReadLine().ToCharArray());
                for (int column = 0; column < columns; column++)
                {
                    matrix[row, column] = inputRow[column];
                }
            }
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int colum = 0; colum < matrix.GetLength(1)-1; colum++)
                {
                    if (matrix[row, colum] == matrix[row, colum + 1] && matrix[row, colum] == matrix[row + 1, colum] &&
                        matrix[row, colum] == matrix[row + 1, colum] &&
                        matrix[row, colum] == matrix[row + 1, colum + 1])
                    {
                        result++;
                    }
                }
            }
            Console.WriteLine(result);
        }
        public static char[] Trim(char[] str)
        {
            return str.Where(x => !Char.IsWhiteSpace(x)).ToArray();
        }
    }
}
