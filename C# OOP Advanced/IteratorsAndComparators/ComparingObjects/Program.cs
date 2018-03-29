using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        string input;

        while ((input=Console.ReadLine())!="END")
        {
            string[] tokens = input.Split();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string town = tokens[2];
            Person person = new Person(name, age, town);
            people.Add(person);
        }

        int personIndex = int.Parse(Console.ReadLine()) - 1;

        Person perstonToCompare = people[personIndex];

        int matches = 0;

        foreach (Person p in people)
        {
            if (p.CompareTo(perstonToCompare)==0)
            {
                matches++;
            }
        }

        if (matches>1)
        {
            Console.WriteLine($"{matches} {people.Count-matches} {people.Count}");
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
}

