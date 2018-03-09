using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace NumbersInReversedOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            PrintReversNumber(number);
        }

        private static void PrintReversNumber(double chislo)
        {
            string revers = chislo.ToString();

            for (int i = revers.Length - 1; i >= 0; i--)
            {
                Console.Write(revers[i]);
            }
            Console.WriteLine();
        }
    }
}
