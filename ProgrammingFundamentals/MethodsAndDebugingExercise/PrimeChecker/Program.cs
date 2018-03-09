using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number = decimal.Parse(Console.ReadLine());
            Console.WriteLine(isPrime(number));
        }

        private static bool isPrime(decimal number)
        {
            if (number == 0 || number == 1)
            {
                return false;
            }
            else
            {
                for (int a = 2; a <= number / 2; a++)
                {
                    if (number % a == 0)
                    {    
                        return false;
                    }

                }
                return true;
            }
        }
    }
}
