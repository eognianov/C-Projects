using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] inputWord = Console.ReadLine().ToCharArray();
            foreach (var chr in inputWord)
            {
                Console.Write("\\u{0:x4}", (int)chr);
            }
            Console.WriteLine();
        }
    }
}
