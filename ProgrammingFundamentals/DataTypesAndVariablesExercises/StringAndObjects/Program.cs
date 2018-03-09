using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "Hello";
            string b = "World";
            object temp = a + " " + b;
            string c = (string)temp;
            Console.WriteLine(c);
        }
    }
}
