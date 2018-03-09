using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseAnArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            string[] items=inputString.Split(' ');
            var reversed = items.Reverse();
            Console.WriteLine(String.Join(" ", reversed));
        }
    }
}
