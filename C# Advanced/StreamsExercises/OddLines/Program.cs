using System;
using System.IO;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineNumber = 0;
            using (var streamRead = new StreamReader("text.txt"))
            {
                string line = streamRead.ReadLine();
                while (line != null)
                {
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    lineNumber++;
                    line = streamRead.ReadLine();
                }
            }
        }
    }
}
