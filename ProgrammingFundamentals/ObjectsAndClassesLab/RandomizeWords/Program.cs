using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] inputWords = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < inputWords.Length; i++)
            {
                Console.WriteLine(inputWords[rnd.Next(0,inputWords.Length)]);
            }

        }
    }
}
