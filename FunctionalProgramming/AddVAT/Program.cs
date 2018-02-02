using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x + x * 0.2)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:f2}"));

        }
    }
}
