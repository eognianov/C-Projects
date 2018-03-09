using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputWords = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string wordOne = inputWords[0];
            string wordTwo = inputWords[1];
            var arrayOne = wordOne.ToCharArray().Distinct().ToArray();
            var arrayTwo = wordTwo.ToCharArray().Distinct().ToArray();
            if (arrayTwo.Length==arrayOne.Length)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

        }
    }
}
