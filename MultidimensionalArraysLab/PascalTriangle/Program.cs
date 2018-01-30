using System;
using System.Linq;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int[][] trignagle = new int[height][];
            int currentWidth = 1;
            for (int row = 0; row < height; row++)
            {
                trignagle[row] = new int[currentWidth];
                int[] currentRow = trignagle[row];
                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;
                currentWidth++;
                if (currentRow.Length > 2)
                {
                    for (int i = 1; i < currentRow.Length-1; i++)
                    {
                        int[] priviousRow = trignagle[row - 1];
                        int privoiousRowSum = priviousRow[i] + priviousRow[i - 1];
                        currentRow[i] = privoiousRowSum;
                    }
                }
            }
            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < row+1; column++)
                {
                    Console.Write(trignagle[row][column] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
