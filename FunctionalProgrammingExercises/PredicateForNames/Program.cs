using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        public static void Main()
        {
            var targetLength = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            Print(names, n => n.Length <= targetLength);
        }

        public static void Print(IEnumerable<string> collection, Func<string, bool> Filter)
        {
            Console.WriteLine(string.Join(Environment.NewLine, collection.Where(Filter)));
        }
    }
}
