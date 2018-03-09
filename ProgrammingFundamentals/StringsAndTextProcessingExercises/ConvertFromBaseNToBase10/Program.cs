using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFromBaseNToBase10
{
    public class ConvertFromBaseNtoBase10
    {
        public static void Main()
        {
            
            var input = Console.ReadLine().Split().ToArray();
            var baseN = int.Parse(input[0]);
            var number = BigInteger.Parse(input[1]);
            var result = ConvertFromNTo10(number, baseN);
            Console.WriteLine(result);
        }

        private static BigInteger ConvertFromNTo10(BigInteger number, int baseN)
        {
            var sum = new BigInteger(0);
            var numAsString = number.ToString();
            for (int i = 0; i < numAsString.Length; i++)
            {
                var num = int.Parse(numAsString[numAsString.Length - 1 - i].ToString());
                sum += num * BigInteger.Pow(baseN, i);
            }

            return sum;
        }
    }
}
