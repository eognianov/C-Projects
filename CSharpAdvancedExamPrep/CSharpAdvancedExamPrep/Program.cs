using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"\[(\w+)<(\d+)(REGEH)(\d+)>(\w+)\]";
            
            List<int> indexes = new List<int>(); 

            foreach (Match m in Regex.Matches(input, pattern))
            {
                indexes.Add(int.Parse(m.Groups[2].Value));
                indexes.Add(int.Parse(m.Groups[4].Value));
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < indexes.Count; i++)
            {
                int previousSum = indexes.Take(i).Sum();
                int currentIndex = previousSum + indexes[i];
                if (currentIndex > input.Length)
                {
                    currentIndex -= input.Length-1;
                }
                result.Append(input[currentIndex]);
            }

            Console.WriteLine(result);
        }
    }
}
