using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var phoneMatches = Regex.Matches(input, @"\+359( ?-?)2\1\d{3}\1\d{4}\b");
            var matchedPhones = phoneMatches.Cast<Match>().Select(a => a.Value.Trim()).ToArray(); 
            
            Console.WriteLine(string.Join(", ",matchedPhones));
        }
    }
}
