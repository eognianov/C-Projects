using System;
using System.Linq;
using System.Text;

namespace MatrixOfPalindroms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intputData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            int rows = intputData[0], columns = intputData[1];
            string[,] matrix = new string[rows,columns];
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    StringBuilder result = new StringBuilder();
                    result.Append(alphabet[row]).Append(alphabet[row + column]).Append(alphabet[row]);
                    matrix[row, column] = result.ToString();
                    result.Clear();
                }
                
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row,column] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
