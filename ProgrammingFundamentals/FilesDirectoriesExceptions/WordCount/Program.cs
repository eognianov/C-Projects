using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> wordsCounter = new Dictionary<string, int>();
            string[] words = File.ReadAllText("words.txt").ToLower().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            List<string> allWords = new List<string>();
            foreach (var word in words)
            {
                wordsCounter.Add(word,0);
            }
            //string[] inputLines = File.ReadAllLines("text.txt").Select(w => w.ToLower()).ToArray();
            //foreach (var line in inputLines)
            //{
            //    var wordsInLine = line.Split(new char[] {' ', '.',',', '!', '-', '?'},
            //        StringSplitOptions.RemoveEmptyEntries);
            //    allWords.AddRange(wordsInLine);
            //}
            allWords = File.ReadAllText("text.txt").ToLower()
                .Split(new char[] { ' ', '.', ',', '!', '-', '?','\n','\r'}, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var word in allWords)
            {
                if (wordsCounter.ContainsKey(word))
                {
                    wordsCounter[word]++;
                }
            }
            File.WriteAllText("output.txt","");
            foreach (var word in wordsCounter.OrderByDescending(x => x.Value))
            {
                File.AppendAllText("output.txt",$"{word.Key} - {word.Value}"+Environment.NewLine);
            }
        }
    }
}
