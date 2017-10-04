using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloName
{
    class Program
    {
        static void PrintHelloName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
        static void Main(string[] args)
        {
            PrintHelloName(Console.ReadLine());
        }
    }
}
