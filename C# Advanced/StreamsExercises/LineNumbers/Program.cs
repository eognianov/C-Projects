using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineNumber = 1;
            using (var streamRead = new StreamReader("text.txt"))
            {
                using (var streamWrite = new StreamWriter("output.txt"))
                {
                    string line = streamRead.ReadLine();
                    while (line != null)
                    {
                        streamWrite.WriteLine($"Line {lineNumber}: {line}");
                        lineNumber++;
                        line = streamRead.ReadLine();
                    }
                }
                
            }
        }
    }
}
