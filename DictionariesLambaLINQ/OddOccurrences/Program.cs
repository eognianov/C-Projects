using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower().Split(' ').ToArray();
            var wordsCounter = new Dictionary<string,int>();
            List<string> results = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if (wordsCounter.ContainsKey(input[i]))
                {
                    wordsCounter[input[i]] ++;
                }
                else
                {
                    wordsCounter.Add(input[i],1);
                }
            }
            foreach (var word in wordsCounter)
            {
                if (word.Value % 2 != 0)
                {
                    results.Add(word.Key);
                }
            }
            
            Console.WriteLine(string.Join(", ",results));
        }
    }
}
