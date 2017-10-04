using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeProperties
{
    class Program
    {
        static double CubePropertiesCalc(double cubeSide, string type)
        {
            double result = 0;
            switch (type)
            {
                case "face":
                    result = Math.Sqrt(2*cubeSide * cubeSide);
                    break;
                case "space":
                    result = Math.Sqrt(3 * cubeSide * cubeSide);
                    break;
                case "volume":
                    result = Math.Pow(cubeSide, 3);
                    break;
                case "area":
                    result = 6 * cubeSide * cubeSide;
                    break;
            }
            return result;
        }

        static void Main(string[] args)
        {
            double cubeSide = double.Parse(Console.ReadLine());
            string propertiesType = Console.ReadLine();
            Console.WriteLine($"{CubePropertiesCalc(cubeSide,propertiesType):F2}");
        }
    }
}
