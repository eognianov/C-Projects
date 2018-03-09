using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();
        for (int i = 0; i < n; i++)
        {
            string[] inputData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string name = inputData[0];
            int age = int.Parse(inputData[1]);
            Person currentPerson = new Person(age, name);
            people.Add(currentPerson);
        }
        foreach (var person in people.Where(p=>p.Age>30).OrderBy(p=>p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}

