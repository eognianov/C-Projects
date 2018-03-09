using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetWings
{
    class Program
    {
        static void Main(string[] args)
        {
            long wingFlaps = long.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            long endurance = long.Parse(Console.ReadLine());

            double distanceTraveled = (wingFlaps / 1000) * distance;
            Console.WriteLine($"{distanceTraveled:F2} m.");

            double timeOfBreaks = wingFlaps / endurance * 5;
            double timeTraveled = wingFlaps / 100;
            Console.WriteLine($"{timeOfBreaks+timeTraveled} s.");
        }
    }
}
