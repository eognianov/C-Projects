using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinoTheWalker
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputTimeParams = Console.ReadLine().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int stepsCount = int.Parse(Console.ReadLine()) % 86400;
            int secPerStep = int.Parse(Console.ReadLine()) % 86400;
            DateTime timeOfLeave = new DateTime(2017, 5, 2, inputTimeParams[0], inputTimeParams[1], inputTimeParams[2]);
            int secondsWalk = stepsCount * secPerStep;
            DateTime timeOfArivel = timeOfLeave.AddSeconds(secondsWalk);
            Console.WriteLine($"Time Arrival: {timeOfArivel.Hour:D2}:{timeOfArivel.Minute:D2}:{timeOfArivel.Second:D2}");
        }
    }
}