using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> results = new List<int>();
            double sqrtNum = 0;
            for (int i = 0; i < inputNumers.Count; i++)
            {
                sqrtNum = Math.Sqrt(inputNumers[i]);
                if (sqrtNum == (int)sqrtNum)
                {
                    results.Add(inputNumers[i]);
                }
            }
            results.Sort((a,b) => b.CompareTo(a));
            Console.WriteLine(string.Join(" ",results));
        }
    }
}
