using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPower
{
    class Program
    {
        static double RaiseToPowerByMath(double number, int power)
        {
            double result = 0d;
            result = Math.Pow(number, power);
            return result;
        }

        static double RaiseToPowerByLoop(double number, int power)
        {
            double result = 1;
            for (int i = 0; i < power; i++)
            {
                result *=number;
            }
            return result;
        }
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine(RaiseToPowerByMath(number,power));
        }
    }
}
