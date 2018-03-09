using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetArmada
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,int>> legionSoldiers = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string,int> legionActivities = new Dictionary<string, int>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var inputArgs = Console.ReadLine().Split(new string[] {" = ", " -> ",":"}, StringSplitOptions.RemoveEmptyEntries);
                int activity = int.Parse(inputArgs[0]);
                string legion = inputArgs[1];
                string soldier = inputArgs[2];
                int count = int.Parse(inputArgs[3]);

                if (!legionActivities.ContainsKey(legion))
                {
                    legionActivities.Add(legion,activity);
                }
                else
                {
                    if (activity < legionActivities[legion])
                    {
                        if (activity < legionActivities[legion])
                        {
                            if (!legionSoldiers[legion].ContainsKey(soldier))
                            {
                                legionSoldiers[legion].Add(soldier,count);
                            }
                            else
                            {
                                legionSoldiers[legion][soldier] += count;
                            }
                        }
                    }
                    else
                    {
                        legionActivities[legion] = activity;
                    }
                }
                if (!legionSoldiers.ContainsKey(legion))
                {
                    legionSoldiers.Add(legion,new Dictionary<string, int>());
                    legionSoldiers[legion].Add(soldier,count);
                }
                else
                {
                    if (!legionSoldiers[legion].ContainsKey(soldier))
                    {
                        legionSoldiers[legion].Add(soldier, count);
                    }
                    else
                    {
                        legionSoldiers[legion][soldier] += count;
                    }
                }
            }

            var printArgs = Console.ReadLine().Split(new char[] {'\\'}, StringSplitOptions.RemoveEmptyEntries);
            if (printArgs.Length > 1)
            {
                int activity = int.Parse(printArgs[0]);
                string soldier = printArgs[1];

                foreach (var legion in legionSoldiers
                    .Where(legion => legionActivities[legion.Key]<activity)
                    .OrderByDescending(legion => legion.Value[soldier]))
                {
                    Console.WriteLine($"{legion.Key} -> {legion.Value[soldier]}");
                }
               
            }
            else
            {
                string soldier = printArgs[0];
                foreach (var legion in legionActivities.Where(legion => legionSoldiers[legion.Key].ContainsKey(soldier))
                    .OrderByDescending(legion => legion.Value))
                {
                    Console.WriteLine($"{legionActivities[legion.Key]}  {legion.Key}");
                }
            }
        }
    }
}
