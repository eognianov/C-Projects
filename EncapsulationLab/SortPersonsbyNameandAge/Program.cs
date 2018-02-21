using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        int personsCount = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>(personsCount);
        for (int counter = 0; counter < personsCount; counter++)
        {
            string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                Person person = new Person(input[0], input[1], int.Parse(input[2]), decimal.Parse(input[3]));
                persons.Add(person);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                
            }  
        }
        Team team = new Team("SoftUni");
        foreach (var person in persons)
        {
            team.AddPlayer(person);
        }
        Console.WriteLine($"First team has {team.FirstTeam.Count}");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count}");
    }
}

