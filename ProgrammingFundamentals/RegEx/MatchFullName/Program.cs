using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            foreach (Match item in Regex.Matches(input, @"\b([A-Z][a-z]+) ([A-Z][a-z]+)\b"))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
