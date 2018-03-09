using System;

namespace Task2
{
    class Program
    {
        static int samRow = 0;
        static int samCol = 0;
        private static int nicRow = 0;
        private static int nicCol = 0;
        static char[][] board;
        private static bool isSamAlive = true;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            board = new char[n][];
            for (int row = 0; row < n; row++)
            {
                char[] intputRow = Console.ReadLine().ToCharArray();
                board[row] = new char[intputRow.Length];
                for (int col = 0; col < intputRow.Length; col++)
                {
                    board[row][col] = intputRow[col];
                    if (intputRow[col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                    }
                    if (intputRow[col] == 'N')
                    {
                        nicRow = row;
                        nicCol = col;
                    }
                }

            }
            char[] commands = Console.ReadLine().ToCharArray();
            int commandIndex = 0;
            while (isSamAlive && samRow != nicRow)
            {
                MoveEnemy();
                ProceedCommand(commands[commandIndex]);
                commandIndex++;
            }
            if (samRow == nicRow)
            {
                board[samRow][samCol] = 'S';
                Console.WriteLine("Nikoladze killed!");
                board[nicRow][nicCol] = 'X';

            }
            if (!isSamAlive)
            {
                Console.WriteLine($"Sam died at {samRow}, {samCol}");
            }



            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    Console.Write(board[row][col]);
                }
                Console.WriteLine();
            }


        }

        private static void ProceedCommand(char command)
        {
            switch (command)
            {
                case 'U':
                    board[samRow][samCol] = '.';
                    samRow -= 1;
                    CheckPosition();
                    break;
                case 'D':
                    board[samRow][samCol] = '.';
                    samRow += 1;
                    CheckPosition();
                    break;
                case 'L':
                    board[samRow][samCol] = '.';
                    samCol -= 1;
                    CheckPosition();
                    break;
                case 'R':
                    board[samRow][samCol] = '.';
                    samCol += 1;
                    CheckPosition();
                    break;
                case 'W':
                    CheckPosition();
                    break;
            }
        }

        private static void CheckPosition()
        {
            if (board[samRow][samCol] == 'b' || board[samRow][samCol] == 'd')
            {
                board[samRow][samCol] = 'X';
            }
            else
            {
                for (int index = 0; index < samCol; index++)
                {
                    if (board[samRow][index] == 'b')
                    {
                        board[samRow][samCol] = 'X';
                        isSamAlive = false;
                        break;
                    }
                }
                for (int index = samCol; index < board[samRow].Length; index++)
                {
                    if (board[samRow][index] == 'd')
                    {
                        board[samRow][samCol] = 'X';
                        isSamAlive = false;
                        break;
                    }
                }
            }
        }

        private static void MoveEnemy()
        {
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == 'b')
                    {
                        board[row][col] = '.';
                        if (col + 1 <= board[row].Length - 1)
                        {
                            board[row][col + 1] = 'b';
                            if (col + 1 == board[row].Length - 1)
                            {
                                board[row][col + 1] = 'd';
                            }
                        }

                        break;
                    }
                    if (board[row][col] == 'd')
                    {
                        board[row][col] = '.';
                        if (col - 1 <= 0)
                        {
                            board[row][col - 1] = 'd';
                            if (col - 1 == 0)
                            {
                                board[row][col - 1] = 'b';
                            }
                        }
                        //if (col - 1 == 0)
                        //    board[row][col - 1] = 'b';
                        //else
                        //{
                        //    board[row][col - 1] = 'd';
                        //}
                        break;
                    }
                }
            }

        }
    }
}