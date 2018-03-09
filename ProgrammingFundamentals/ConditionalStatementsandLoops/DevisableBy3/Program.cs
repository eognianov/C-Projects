using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevisableBy3
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;
            for (var i =1;i<=n;i++)
            {
                Console.WriteLine("{0}", 2 * i - 1);
                sum += 2 * i - 1;
            }
            Console.WriteLine($"Sum:{sum}");
        }
    }
}
