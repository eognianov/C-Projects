using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> namePeople = new SortedSet<Person>(new PersonNameComparer());
        SortedSet<Person> agePeople = new SortedSet<Person>(new PersonAgeComparer());

        int peopleCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < peopleCount; i++)
        {
            string[] input = Console.ReadLine().Split();
            int age = int.Parse(input[1]);

            Person person = new Person(input[0],age);

            namePeople.Add(person);
            agePeople.Add(person);
        }

        Console.WriteLine(string.Join(Environment.NewLine, namePeople));
        Console.WriteLine(string.Join(Environment.NewLine, agePeople));
    }
}

