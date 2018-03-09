using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConversion
{
    class Program
    {
        static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
        static void Main(string[] args)
        {
            double tempInFahrenheit = Double.Parse(Console.ReadLine());
            Console.WriteLine($"{FahrenheitToCelsius(tempInFahrenheit):F2}");

        }
    }
}
