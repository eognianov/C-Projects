using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        


        public static void Main()
        {
            string pattern = @"([A-Za-z]+)(.+)(\1)";
            string encodedText = Console.ReadLine();
            string[] placeHolders = Console.ReadLine().Split(new char[] {'{', '}'},StringSplitOptions.RemoveEmptyEntries).ToArray();

            int placeHolderIndex = 0;
            foreach (Match m in Regex.Matches(encodedText, pattern))
            {

                string toReplace = m.Groups[2].Value;
                encodedText = encodedText.Replace(toReplace, placeHolders[placeHolderIndex]);
                placeHolderIndex++;
                if (placeHolderIndex > placeHolders.Length)
                {
                    placeHolderIndex = 0;
                }
            }
            Console.WriteLine(encodedText);
        }
    }
}
