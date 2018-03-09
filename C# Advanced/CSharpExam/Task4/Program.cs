using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string,string>> people = new Dictionary<string, Dictionary<string, string>>();
            while (true)
            {
                string inputArgs = Console.ReadLine();
                if (inputArgs.StartsWith("end"))
                {
                    break;
                }

                string[] inputData = inputArgs.Split(new char[] {'='}, StringSplitOptions.RemoveEmptyEntries);
                string personName = inputData[0];

                if (!people.ContainsKey(personName))
                {
                    people.Add(personName,new Dictionary<string, string>());
                }
                string[] personInfo = inputData[1].Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var information in personInfo)
                {
                    string[] info =information.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    string infoName = info[0];
                    string infoValue = info[1];
                    if (!people[personName].ContainsKey(infoName))
                    {
                        people[personName].Add(infoName,"");
                    }
                    people[personName][infoName] = infoValue;
                }

            }
            string[] kill = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string targetName = kill[1];
            Console.WriteLine($"Info on {targetName}:");
            int indexInfo = 0;
            foreach (var info in people[targetName].OrderBy(x=>x.Key))
            {
                indexInfo += info.Key.Length + info.Value.Length;
                Console.WriteLine($"---{info.Key}: {info.Value}");
            }
            Console.WriteLine($"Info index: {indexInfo}");
            if (indexInfo >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex-indexInfo} more info.");
            }
        }
    }
}
