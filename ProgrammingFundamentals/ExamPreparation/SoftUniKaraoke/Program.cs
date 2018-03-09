using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniKaraoke
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = Console.ReadLine().Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] songs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] awardDetails = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Dictionary<string,List<string>> awards = new Dictionary<string, List<string>>();
            while (awardDetails[0] != "dawn")
            {
                string person = awardDetails[0];
                string song = awardDetails[1];
                string award = awardDetails[2];
                if (person.Contains(person) && songs.Contains(song))
                {
                    if (awards.ContainsKey(person))
                    {
                        awards[person].Add(award);
                    }
                    else
                    {
                        awards.Add(person,new List<string>());
                        awards[person].Add(award);
                    }
                }
                awardDetails = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            }
            if (awards.Count != 0)
            {
                foreach (var person in awards.OrderByDescending(x => x.Value.Distinct().Count()).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{person.Key}: {awards[person.Key].Distinct().Count()} awards");
                    foreach (var award in person.Value.Distinct().OrderBy(x => x))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
