using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputRange = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string format = Console.ReadLine();

            List<int> numbers = new List<int>();
            for (int i = inputRange[0]; i <= inputRange[1]; i++)
            {
                numbers.Add(i);
            }


            Predicate<int> even = x => { return x % 2 == 0; };
            Predicate<int> odd = x => { return x % 2 != 0; };


            List<int> result = new List<int>();
            if (format=="odd")
            {
                result = numbers.FindAll(odd);
            }
            else
            {
                result = numbers.FindAll(even);
            }

            Console.WriteLine(string.Join(" ",result));

        }


    }
}
