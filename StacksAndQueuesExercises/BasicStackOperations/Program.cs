using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int elemetToPush = inputData[0];
            int elementToPop = inputData[1];
            int elementToSearch = inputData[2];
            int[] inputIntegers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Stack<int> elements = new Stack<int>(inputIntegers);
            for (int i = 0; i < elementToPop; i++)
            {
                elements.Pop();
            }
            if (elements.Contains(elementToSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                if(elements.Count >0)
                    Console.WriteLine(elements.Min());
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
