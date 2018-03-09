using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    class Program
    {
        static void Main( )
        {
            string[] inputWords = Console.ReadLine().Split(new char[] {' ',',','.','?','!'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<string> palindromes = new List<string>();

            foreach (var word in inputWords)
            {
                if (isPalindrom(word))
                {
                    palindromes.Add(word);
                }
            }
            //palindromes.Sort();
            palindromes = palindromes.Distinct().OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(", ",palindromes));

        }

        private static bool isPalindrom(string word)
        {
            char[] wordLetters = word.ToCharArray();
            string reversedWord = string.Empty;
            for (int i = wordLetters.Length - 1; i >= 0; i--)
            {
                reversedWord += wordLetters[i];
            }
            if (word == reversedWord)
            {
                return true;
            }
            
            return false;
        }
    }
}
