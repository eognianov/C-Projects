using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputText = File.ReadAllLines("Input.txt");
            
            //for (int i = 0; i < intputText.Length; i++)
            //{
            //    if (i % 2 != 0)
            //    {
            //        File.AppendAllText("output.txt", $"{i}. {intputText[i]}"+Environment.NewLine);
            //        Console.WriteLine($"{i}. {intputText[i]}");
            //    }
            //}

            string[] oddLines = inputText.Where((line, i) => i % 2 != 0).ToArray();
            File.WriteAllLines("output1.txt",oddLines);
        }
    }
}
