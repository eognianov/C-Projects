using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxSum = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int n = N;n>=1;n--)
            {
                for (int m = 1;m<=M;m++)
                {
                   
                    sum += (3 * m * n);
                    counter++;
                    if(sum >= maxSum)
                    {
                        Console.WriteLine($"{counter} combinations" +Environment.NewLine+ $"Sum: {sum} >= {maxSum} ");
                        return;
                    }
                }
            }
            Console.WriteLine($"{counter} combinations"+Environment.NewLine+$"Sum: {sum}");
        }
    }
}
