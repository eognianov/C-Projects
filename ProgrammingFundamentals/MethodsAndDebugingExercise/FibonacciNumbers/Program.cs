using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    class Program
    {
        static int Fib(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            int firstNumber = 1;
            int secondNumber = 1;
            int fibNumber = 0;
            for (int i = 0; i <= n-2; i++)
            {
                fibNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = fibNumber;
            }
            return fibNumber;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(n));

        }
    }
}
