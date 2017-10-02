using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableInHexFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            int outputNumber = Convert.ToInt32(inputLine, 16);
            Console.WriteLine(outputNumber);
        }
    }
}
