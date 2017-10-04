using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFilledSquare
{
    class Program
    {
        static void printBorder(int n)
        {
            Console.WriteLine(new string('-',2*n));
        }

        static void printMiddleRow(int n)
        {
            Console.Write('-');
            for (int i = 1; i < n; i++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine("-");
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            printBorder(n);
            for (int i = 1; i <=n-2; i++)
            {
                printMiddleRow(n);
            }
            
            printBorder(n);
        }
    }
}
