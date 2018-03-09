using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractSentencesByKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyword = Console.ReadLine();

            string[] intputSentences = Console.ReadLine().Split(new char[] {'.','!','?'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            foreach (string sentence in intputSentences)
            {
                string[] currentSenteceWords = Regex.Split(sentence, @"[^A-Za-z]");
                if (currentSenteceWords.Contains(keyword))
                {
                    Console.WriteLine(sentence.Trim());
                }
            }
        }
    }
}
