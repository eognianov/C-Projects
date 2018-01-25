using System;
using System.Collections.Generic;

namespace ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNumbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Stack<string> reverseNumbers = new Stack<string>(inputNumbers);
            while (reverseNumbers.Count > 0)
            {
                Console.Write(reverseNumbers.Pop() + " ");
            }
        }
    }
}
