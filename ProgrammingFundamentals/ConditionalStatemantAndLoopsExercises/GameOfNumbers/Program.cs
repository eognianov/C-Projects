using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int combinationCounter = 0;
            int magicNumber = int.Parse(Console.ReadLine());
            int found = 0;
            int lastI = 0;
            int lastJ = 0;
            for (int i = N; i <= M; i++)
            {
                for (int j = N; j <= M; j++)
                {
                    combinationCounter++;
                    if ((i + j) == magicNumber)
                    {
                        found = 1;
                        lastI = i;
                        lastJ = j;
                    }
                }
            }
            if (found != 0)
            {
                Console.WriteLine($"Number found! {lastI} + {lastJ} = {magicNumber}");
            }
            else {
                Console.WriteLine($"{combinationCounter} combinations - neither equals {magicNumber}");
            }
        }
    }
}
