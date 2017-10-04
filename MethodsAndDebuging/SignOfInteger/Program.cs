using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignOfInteger
{
    class Program
    {
        static string SignOfIntegerCheck(int num)
        {
            string sign = "";
            if (num < 0)
            {
                sign = "negative";
            }
            else if(num == 0)
            {
                sign = "zero";
            }
            else if (num > 0)
            {
                sign = "positive";
            }
            return sign;
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string signOfInt = SignOfIntegerCheck(num);
            Console.WriteLine($"The number {num} is {signOfInt}.");

        }

    }
}
