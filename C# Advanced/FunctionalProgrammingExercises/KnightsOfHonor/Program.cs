using System;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Action<string> printName = s => Console.WriteLine($"Sir {s}");
            foreach (var name in inputNames)
            {
                printName(name);
            }
        }
    }
}
