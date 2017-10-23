using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        public static void Main()
        {
            long[] numbers = File.ReadAllText("Input.txt")
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
            int start = 0;
            int bestStart = 0;
            int length = 0;
            int bestLength = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[start] == numbers[i])
                {
                    length++;
                    if (length > bestLength)
                    {
                        bestLength = length;
                        bestStart = start;
                    }
                }
                else
                {
                    start++;
                    i = start;
                    length = 0;
                }
            }
            File.WriteAllText("Output.txt","");
            for (int i = 0; i <= bestLength; i++)
            {
                File.AppendAllText("Output.txt",$"{numbers[bestStart+i]} ");
            }
        }
    }
}
