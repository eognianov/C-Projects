using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexofLetters
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] input = Console.ReadLine().ToLower().ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine("{0} -> {1}", input[i], (int)(input[i] - 97));
            }
        }
    }
}
