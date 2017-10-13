using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] inputNumbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var counts =new SortedDictionary<double, int>();
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                if (counts.ContainsKey(inputNumbers[i]))
                {
                    counts[inputNumbers[i]] ++;
                }
                else
                {
                    counts.Add(inputNumbers[i],1);
                }
            }
            foreach (var pair in counts)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
