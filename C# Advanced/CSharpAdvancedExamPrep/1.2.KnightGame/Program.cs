using System;
using System.Data;

namespace _1._2.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var boadrSize = int.Parse(Console.ReadLine());
            int countOfRemovedKnights = 0;
            char[][] board = new char[boadrSize][];
            for (int counter = 0; counter < boadrSize; counter++)
            {
                board[counter] = Console.ReadLine().ToCharArray();
            }

            int maxRow = 0;
            int maxColumn = 0;
            int maxAttackedPositions = 0;

            do
            {
                if (maxAttackedPositions > 0)
                {
                    board[maxRow][maxColumn] = '0';
                    maxAttackedPositions = 0;
                    countOfRemovedKnights++;
                }

                int currentAttackPositions = 0;

                for (int row = 0; row < boadrSize; row++)
                {
                    for (int column = 0; column < boadrSize; column++)
                    {
                        if (board[row][column] == 'K')
                        {
                            currentAttackPositions = CalculateAttackedPositions(row, column, board);
                            if (currentAttackPositions>maxAttackedPositions)
                            {
                                maxAttackedPositions = currentAttackPositions;
                                maxRow = row;
                                maxColumn = column;
                            }
                        }
                    }
                }
            }
            while (maxAttackedPositions > 0);
            Console.WriteLine(countOfRemovedKnights);
        }

        static int CalculateAttackedPositions(int row, int column, char[][] board)
        {
            var currentAttackPostions = 0;
            if (isPositionAttacked(row-2, column-1,board))
            {
                currentAttackPostions++;
            }
            if (isPositionAttacked(row - 2, column + 1, board))
            {
                currentAttackPostions++;
            }
            if (isPositionAttacked(row - 1, column - 2, board))
            {
                currentAttackPostions++;
            }
            if (isPositionAttacked(row - 1, column + 2, board))
            {
                currentAttackPostions++;
            }
            if (isPositionAttacked(row + 1, column - 2, board))
            {
                currentAttackPostions++;
            }
            if (isPositionAttacked(row + 1, column + 2, board))
            {
                currentAttackPostions++;
            }
            if (isPositionAttacked(row + 2, column - 1, board))
            {
                currentAttackPostions++;
            }
            if (isPositionAttacked(row + 2, column + 1, board))
            {
                currentAttackPostions++;
            }

            return currentAttackPostions;
        }

        static bool isPositionAttacked(int row, int column, char[][] board)
        {
            return isPositionWithinBoard(row, column, board[0].Length) && board[row][column] == 'K';
        }

        static bool isPositionWithinBoard(int row, int column, int boardSize)
        {
            return row >= 0 && row < boardSize && column >= 0 && column < boardSize;
        }
    }
}
