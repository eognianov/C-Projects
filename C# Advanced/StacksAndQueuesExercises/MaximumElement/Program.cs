using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueries = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            int max = 1;
            for (int i = 0; i < numberOfQueries; i++)
            {
                int[] commandArgs = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                switch (commandArgs[0])
                {
                    case 1:
                        if (commandArgs[1] > max)
                            max = commandArgs[1];
                        numbers.Push(commandArgs[1]);
                        break;
                    case 2:
                        numbers.Pop();
                        break;
                    case 3:
                        Console.WriteLine(max);
                        break;
                }
            }
        }
    }
}
