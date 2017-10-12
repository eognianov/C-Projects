using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitbyWordCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> stringList = input.Split(new char[] { ' ', ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']' },
                StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> lowerCase = new List<string>();
            List<string> upperCase = new List<string>();
            List<string> mixedCase = new List<string>();

            string currentWord = string.Empty;
            bool isLower = false;
            bool isUpper = false;

            for (int i = 0; i < stringList.Count; i++)
            {
                currentWord = stringList[i];

                isUpper = CheckIfUpper(currentWord);
                isLower = CheckIfLower(currentWord);

                if (isUpper == true && isLower == false)
                {
                    upperCase.Add(currentWord);
                }
                else if (isLower == true && isUpper == false)
                {
                    lowerCase.Add(currentWord);
                }
                else if (isLower == false && isUpper == false || isLower == true && isUpper == true)
                {
                    mixedCase.Add(currentWord);
                }

                isLower = false;
                isUpper = false;

            }

            Console.Write("Lower-case: ");
            Console.WriteLine(string.Join(", ", lowerCase));

            Console.Write("Mixed-case: ");
            Console.WriteLine(string.Join(", ", mixedCase));

            Console.Write("Upper-case: ");
            Console.WriteLine(string.Join(", ", upperCase));

        }

        static bool CheckIfUpper(string currentWord)
        {

            bool isOnlyLetters = currentWord.All(Char.IsLetter);
            bool isOnlyUpper = currentWord.All(Char.IsUpper);

            if (isOnlyLetters == true && isOnlyUpper == true)
            {
                return true;
            }

            return false;
        }

        static bool CheckIfLower(string currentWord)
        {

            bool isOnlyLetters = currentWord.All(Char.IsLetter);
            bool isOnlyLower = currentWord.All(Char.IsLower);
            if (isOnlyLetters == true && isOnlyLower == true)
            {
                return true;
            }

            return false;
        }

    }
}
