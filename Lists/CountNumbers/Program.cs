using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] count = new int[1000];
            for (int i = 0; i <inputNumbers.Count; i++)
            {
                count[inputNumbers[i]]++;
            }
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] != 0)
                {
                    Console.WriteLine($"{i} -> {count[i]}");
                }
            }
        }
    }
}
