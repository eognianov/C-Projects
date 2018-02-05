using System;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string> printName = s => Console.WriteLine(s);
            foreach (var name in inputNames)
            {
                printName(name);
            }
        }
    }
}
