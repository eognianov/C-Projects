using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPrimeCheckerRefactor
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNumber = int.Parse(Console.ReadLine());
            for (int currentNumber = 2; currentNumber <= lastNumber; currentNumber++)
            {
                bool primeCheck = true;
                for (int devizionNumber = 2; devizionNumber <= Math.Sqrt(currentNumber); devizionNumber++)
                {
                    if (currentNumber % devizionNumber == 0)
                    {
                        primeCheck = false;
                        break;
                    }
                }
                Console.WriteLine($"{currentNumber} -> {primeCheck}");
            }
        }
    }
}
