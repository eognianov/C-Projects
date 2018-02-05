using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace _1._2.KnightGame
{
    class Program
    {
        public static char[,] board;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            board = new char[n,n];
            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    board[row, col] = currentRow[col];
                }

            }
            int counter = 0;
            for (int row = 0; row < n-2; row++)
            {
                for (int col = 0; col < n-2; col++)
                {
                    if (board[row, col].Equals('K'))
                    {
                        if (board[row,col].Equals(board[row+2,col+1]) || board[row,col].Equals(board[row+1,col+2]))
                        {
                            ro
                            counter++;

                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }

        //public static bool CheckPosition(int row, int col)
        //{
        //    try
        //    {
        //        board[row,col].Equals(board[row+2,col+1])
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //    return false;
        //}
    }
}
