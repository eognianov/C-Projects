using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = File.ReadAllText("Input.txt")
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            bool isFindEqualSums = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                int[] leftSide = numbers.Take(i).ToArray();
                int[] rightSide = numbers.Skip(i + 1).ToArray();
                if (leftSide.Sum() == rightSide.Sum())
                {
                    File.WriteAllText("Output.txt", $"{i}");
                    isFindEqualSums = true;
                    break;
                }
            }
            if (!isFindEqualSums)
            {
                File.WriteAllText("Output.txt", "no");
            }
        }
    }
}
