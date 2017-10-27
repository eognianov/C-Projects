using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchHexadecimalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"\b(?:0x)?[0-9A-F]+\b";
            var numbersString = Console.ReadLine();
            var numbers = Regex.Matches(numbersString, regex).Cast<Match>().Select(a => a.Value).ToArray();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
