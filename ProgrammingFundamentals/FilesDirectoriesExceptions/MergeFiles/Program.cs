using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeFiles
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string[] firslFileLines = File.ReadAllLines("FileOne.txt");
            string[] secondFileLines = File.ReadAllLines("FileTwo.txt");
            int mergedBorder = 0;   
            List<string> mergedText = new List<string>();
            for (int i = 0; i < Math.Min(firslFileLines.Length,secondFileLines.Length); i++)
            {
               mergedText.Add(firslFileLines[i]);
               mergedText.Add(secondFileLines[i]);
                mergedBorder = i;
            }
            //if (mergedBorder != firslFileLines.Length)
            //{
            //    mergedText.AddRange(firslFileLines.Skip(mergedBorder));
            //}
            //else if(mergedBorder!=secondFileLines.Length)
            //{
            //    mergedText.AddRange(secondFileLines.Skip(mergedBorder));
            //}
            File.WriteAllText("output.txt", "");
            foreach (var line in mergedText)
            {
                File.AppendAllText("output.txt",line+Environment.NewLine);
            }
        }
    }
}
