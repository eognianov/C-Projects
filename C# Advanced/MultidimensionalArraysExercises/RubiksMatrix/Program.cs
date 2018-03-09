using System;
using System.Collections.Generic;
using System.Linq;

namespace RubiksMatrix
{
    class Program
    {
        private static int[,] matrix;
        private static int rows;
        private static int columns;


        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            matrix = new int[dimensions[0],dimensions[1]];
            rows = dimensions[0];
            columns = dimensions[1];
            int commandCount = int.Parse(Console.ReadLine());
            int number = 1;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    matrix[row, column] = number++;
                }
            }

            for (int i = 0; i < commandCount; i++)
            {
                ParseCommnad();
            }

            RearrangeMatrix();
        }

        private static void RearrangeMatrix()
        {
            int expected = 1;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (matrix[row, col] == expected)
                    {
                        Console.WriteLine("No swap required");
                        
                        
                    }
                    else
                    {
                        for (int r = 0; r < rows; r++)
                        {
                            for (int c = 0; c < columns; c++)
                            {
                                if (matrix[r, c] == expected)
                                {
                                    int temp = matrix[row, col];
                                    matrix[row, col] = matrix[r, c];
                                    matrix[r, c] = temp;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                                    
                                    
                                }
                            }
                        }
                    }
                    expected++;
                }
            }
        }

        private static void ParseCommnad()
        {
            string[] commnadArgs = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string command = commnadArgs[1];
            int index = int.Parse(commnadArgs[0]);
            int rotations = int.Parse(commnadArgs[2]);
            switch (command)
            {
                case "up":
                    MoveColumn(index, columns - (rotations % rows));
                    break;
                case "down":
                    MoveColumn(index, (rotations % rows));
                    break;
                case "left":
                    MoveRow(index,rows - (rotations % columns));
                    break;
                case "right":
                    MoveRow(index, (rotations % columns));
                    break;
            }
        }

        private static void MoveRow(int index, int rotations)
        {
            //rotations %= columns;
            int[] temp = new int[columns];
            for (int col = 0; col < columns; col++)
            {
                int replacementIndex = col + rotations;
                replacementIndex %= columns;
                temp[replacementIndex] = matrix[index, col];
            }

            for (int col = 0; col < columns; col++)
            {
                matrix[index, col] = temp[col];
            }
        }

        private static void MoveColumn(int index, int rotations)
        {
            //rotations %= rows;
            int[] temp = new int[rows];
            for (int row = 0; row < rows; row++)
            {
                int replacementIndex = row + rotations;
                replacementIndex %= rows;
                temp[replacementIndex] = matrix[index, row];
            }

            for (int row = 0; row < rows; row++)
            {
                matrix[row,index] = temp[row];
            }
        }
    }
}
