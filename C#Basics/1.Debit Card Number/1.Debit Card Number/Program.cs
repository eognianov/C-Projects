using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Debit_Card_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());
            var third = int.Parse(Console.ReadLine());
            var fourth = int.Parse(Console.ReadLine());
            Console.WriteLine("{0:D4} {1:D4} {2:D4} {3:D4}", first, second, third, fourth);
        }
    }
}
