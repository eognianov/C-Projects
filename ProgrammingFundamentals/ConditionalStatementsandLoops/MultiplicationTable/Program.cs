using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var chislo = int.Parse(Console.ReadLine());
            for (var i = 1; i <=10; i++)
            {
                Console.WriteLine("{0} X {1} = {2}", chislo, i, chislo * i);
            }
        }
    }
}
