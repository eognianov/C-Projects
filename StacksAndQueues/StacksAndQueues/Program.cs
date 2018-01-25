using System;
using System.Collections.Generic;

namespace StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reverseInput = new Stack<char>(input.ToCharArray());
            while (reverseInput.Count>0)
            {
                Console.Write(reverseInput.Pop());
            }
        }
    }
}
