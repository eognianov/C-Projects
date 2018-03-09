using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> words = new Dictionary<string, int>();
            using (var streamWords = new StreamReader("words.txt"))
            {
                string word = streamWords.ReadLine();
                while (word!=null)
                {
                    words.Add(word,0);
                    word = streamWords.ReadLine();
                }
            }
            using (var streamText = new StreamReader("text.txt"))
            {
                string textLine = streamText.ReadLine();
                while (textLine!=null)
                {
                    string[] wordsFromText = textLine.ToLower()
                        .Split(new char[] { ' ', '.', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    foreach (var word in wordsFromText)
                    {
                        if (words.ContainsKey(word))
                        {
                            words[word]++;
                        }
                    }
                    textLine = streamText.ReadLine();
                }
            }

            using (var writeResult = new StreamWriter("result.txt"))
            {
                foreach (var result in words.OrderByDescending(x=>x.Value))
                {
                    writeResult.WriteLine($"{result.Key} - {result.Value}");
                }
            }
        }
    }
}
