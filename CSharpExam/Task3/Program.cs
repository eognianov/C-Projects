using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfRows = int.Parse(Console.ReadLine());
            StringBuilder input = new StringBuilder();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < numbersOfRows; i++)
            {
                input.Append(Console.ReadLine());
            }
            string pattern = @"\{[a-zA-z*><~.\s]*(?<digits>\d{3,})[a-zA-z*><~.\s]*\}|\[[a-zA-z**><~.\s]*(?<digits>\d{3,})[a-zA-z*><~.\s]*\]";
            

            foreach (Match m in Regex.Matches(input.ToString(), pattern))
            {

                if (m.Groups["digits"].Value.Length % 3 == 0)
                {
                    List<string> sepparetedNumbers = new List<string>();
                    for (int i = 0; i < m.Groups["digits"].Value.Length; i+=3)
                    {
                        sepparetedNumbers.Add(m.Groups["digits"].Value.Substring(i,3));
                    }
                    foreach (var numbers in sepparetedNumbers)
                    {
                        int charNumber = int.Parse(numbers)-m.Length;
                        result.Append((char)charNumber);
                    }
                }
            }
            Console.WriteLine(result.ToString());
        }
    }
}
