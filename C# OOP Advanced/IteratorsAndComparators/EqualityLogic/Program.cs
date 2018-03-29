using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashSet = new HashSet<Person>();
            var sortedSet = new SortedSet<Person>();

            var counter = int.Parse(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                var personArgs = Console.ReadLine().Split();
                var person = new Person(personArgs[0], int.Parse(personArgs[1]));

                hashSet.Add(person);
                sortedSet.Add(person);
            }

            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);
        }
    }
}
