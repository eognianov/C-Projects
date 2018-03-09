using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldInPlural
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            char lastChar = word.Last();
            switch (lastChar)
            {
                case 'y':
                    word = word.Substring(0, word.Length - 1);
                    Console.WriteLine($"{word}ies");
                    break;
                case 'h':
                case 'o':
                case 's':
                case 'x':
                case 'z':
                    Console.WriteLine($"{word}es");
                    break;
                default:
                    Console.WriteLine($"{word}s");
                    break;
            }

        }
    }
}
