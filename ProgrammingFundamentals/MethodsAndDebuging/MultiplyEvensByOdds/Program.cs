using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static int GetTheSumOfOdds(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 != 0)
                {
                    sum += lastDigit;
                }
                n /= 10;
            }
            return sum;
        }
        static int GetTheSumOfEvens(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 == 0)
                {
                    sum += lastDigit;
                }
                n /= 10;
            }
            return sum;
        }

        private static int GetMultipleOfEvenAndOdds(int n)
        {
            int sumEvens = GetTheSumOfEvens(n);
            int sumOdds = GetTheSumOfOdds(n);
            return sumOdds * sumEvens;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMultipleOfEvenAndOdds(Math.Abs(n)));

        }
    }
}
