using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTableVer2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int chislo = int.Parse(Console.ReadLine());
            int puti = int.Parse(Console.ReadLine());
            if (puti <= 10)
            {
                for (var i = puti; i <= 10;i++)
                {
                    Console.WriteLine("{0} X {1} = {2}", chislo, i, chislo * i);
                }
            }
            else
            {
                Console.WriteLine("{0} X {1} = {2}", chislo, puti, chislo * puti);
            }
        }
    }
}
