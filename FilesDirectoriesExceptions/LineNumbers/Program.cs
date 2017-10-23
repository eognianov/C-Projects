using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLines = File.ReadAllLines("Input.txt");
            //for (int i = 0; i < inputLines.Length; i++)
            //{
            //    File.AppendAllText("output.txt",$"{i+1}. {inputLines[i]}"+Environment.NewLine);
            //}
            var numberedLines = inputLines.Select((line, index) => $"{index + 1}. {line}");
            File.WriteAllLines("output1.txt", numberedLines);
        }
    }
}
