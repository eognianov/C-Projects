using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bannedWords = Console.ReadLine().Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var text = Console.ReadLine();
            foreach (var word in bannedWords)
            {
                text = text.Replace(word,new string('*',word.Length));
            }
            Console.WriteLine(text);
        }
    }
}
