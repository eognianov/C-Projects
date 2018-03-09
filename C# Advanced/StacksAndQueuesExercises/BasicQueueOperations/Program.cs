using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArgs = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int numberOfElements = inputArgs[0];
            int elementsToDeque = inputArgs[1];
            int elementToSearch = inputArgs[2];
            int[] inputNumbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>(inputNumbers);
            for (int i = 0; i < elementsToDeque; i++)
            {
                numbers.Dequeue();
            }
            if (numbers.Contains(elementToSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                if(numbers.Count!=0)
                    Console.WriteLine(numbers.Min());
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
