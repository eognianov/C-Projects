using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Add_two_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, sum;
            a = Console.Read();
            b = Console.Read();
            sum = a + b;
            Console.WriteLine("{0} + {1} = {2}", a, b, sum);
        }
    }
}
