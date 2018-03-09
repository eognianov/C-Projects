using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var OpenBracketsIndexs = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] =='(')
                {
                    OpenBracketsIndexs.Push(i);
                }
                if(input[i]== ')')
                {
                    var openBracketIndex = OpenBracketsIndexs.Pop();
                    var lenght = i - openBracketIndex + 1;
                    Console.WriteLine(input.Substring(openBracketIndex, lenght));
                }
            }
        }
    }
}
