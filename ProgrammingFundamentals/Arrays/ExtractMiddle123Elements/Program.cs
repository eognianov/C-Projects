using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractMiddle123Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrNumbers = Console.ReadLine().Split(' ').ToArray();
            int n = arrNumbers.Length;
            if (n == 1)
            {
                Console.WriteLine("{ " + arrNumbers[0] + " }");
            }
            else
            {
                if (n % 2 == 0)
                {
                    Console.WriteLine("{ "+$"{arrNumbers[n/2-1]}, {arrNumbers[n/2]}"+" }");
                }
                else
                {
                    Console.WriteLine("{ "+$"{arrNumbers[n/2-1]}, {arrNumbers[n/2]}, {arrNumbers[n/2+1]}" + " }");
                }
            }

        }
    }
}
