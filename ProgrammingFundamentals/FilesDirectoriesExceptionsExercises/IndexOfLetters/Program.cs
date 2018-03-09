using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] input = File.ReadAllText("Input.txt").ToCharArray();
            File.WriteAllText("Output.txt","");
            for (int i = 0; i < input.Length; i++)
            {
                File.AppendAllText("Output.txt", $"{input[i]} -> {(int)(input[i] - 97)}"+Environment.NewLine);
               
            }
        }
    }
}
