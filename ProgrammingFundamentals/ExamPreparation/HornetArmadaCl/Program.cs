﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetArmadaCl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Legion> legions = new List<Legion>();
            long n = long.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var inputArgs = Console.ReadLine()
                    .Split(new string[] {" = ", " -> ", ":"}, StringSplitOptions.RemoveEmptyEntries);
                long activity = long.Parse(inputArgs[0]);
                string legion = inputArgs[1];
                string soldier = inputArgs[2];
                long count = long.Parse(inputArgs[3]);
                if (!legions.Any(l => l.Name == legion))
                {
                    Legion currentLegion =new Legion(){Activity = activity,Name = legion,Soldiers = new Dictionary<string, long>()};

                    currentLegion.Soldiers.Add(soldier,count);
                    legions.Add(currentLegion);                    
                }
                else
                {
                    Legion currentLegion = legions.FirstOrDefault(l => l.Name == legion);
                    if (currentLegion.Activity < activity)
                    {
                        currentLegion.Activity = activity;
                    }
                    if (!currentLegion.Soldiers.ContainsKey(soldier))
                    {
                        currentLegion.Soldiers.Add(soldier,count);
                    }
                    else
                    {
                        currentLegion.Soldiers[soldier] += count;
                    }
                }
            }
            var printArgs = Console.ReadLine().Split('\\');
            if (printArgs.Length > 1)
            {
                long activity = long.Parse(printArgs[0]);
                string soldier = printArgs[1];
                Dictionary<string, long> rem = new Dictionary<string, long>();

                foreach (var legion in legions.Where(l => l.Activity<activity).Where(l => l.Soldiers.ContainsKey(soldier)))
                {
                    rem.Add(legion.Name,legion.Soldiers[soldier]);
             
                }
                foreach (var l in rem.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"{l.Key} -> {l.Value}");
                }
            }
            else
            {
                string soldier = printArgs[0];
                foreach (var legion in legions.Where(l => l.Soldiers.ContainsKey(soldier)).OrderByDescending(l=>l.Activity))
                {
                    Console.WriteLine($"{legion.Activity} : {legion.Name}");
                }
            }
        }
    }

    class Legion
    {
        public string Name { get; set; }
        public long Activity { get; set; }
        public Dictionary<string,long> Soldiers { get; set; }
    }
}
