using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerToHexAndBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());
            string hexNumber = Convert.ToString(decimalNumber, 16).ToUpper();
            string binaryNumber = Convert.ToString(decimalNumber, 2);
            Console.WriteLine(hexNumber);
            Console.WriteLine(binaryNumber);
        }
    }
}
