using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberA = int.Parse(Console.ReadLine());
            int numberB = int.Parse(Console.ReadLine());
            if (numberA>numberB)
            {
                for (int i =numberB;i<=numberA;i++)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                for (int i = numberA; i <= numberB; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
