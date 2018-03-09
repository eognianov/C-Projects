using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int number = i;
                int obshto = 0;
                while (i > 0)
                {
                    obshto += i % 10;
                    i = i / 10;
                }
                bool check = (obshto == 5) || (obshto == 7) || (obshto == 11);
                Console.WriteLine($"{number} -> {check}");
                obshto = 0;
                i = number;
            }
        }
    }
}
