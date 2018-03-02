using System;
using System.Collections.Generic;
using System.Linq;


public class StartUp
{
    static void Main(string[] args)
    {
        var soldiers = new List<ISoldier>();
        string input;
        while ((input = Console.ReadLine())!="End")
        {
            string[] tokens = input.Split();
            string soldierType = tokens[0];
            int id = int.Parse(tokens[1]);
            string firstName = tokens[2];
            string lastName = tokens[3];
            decimal salary = decimal.Parse(tokens[4]);

            ISoldier soldier = null;
            try
            {
                switch (soldierType)
                {
                    case "Private":
                        soldier = new Private(id, firstName, lastName, salary);
                        break;
                    case "LeutenantGeneral":
                        var leutenant = new LeutenantGeneral(id, firstName, lastName, salary);

                        for (int i = 5; i < tokens.Length; i++)
                        {
                            int soldierId = int.Parse(tokens[i]);
                            ISoldier @private = soldiers.First(p => p.Id == soldierId);
                            leutenant.AddPrivate(@private);
                        }
                        soldier = leutenant;
                        break;
                    case "Engineer":
                        string engineerCorps = tokens[5];
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, engineerCorps);

                        for (int i = 6; i < tokens.Length; i++)
                        {
                            string partName = tokens[i];
                            int hoursWorked = int.Parse(tokens[++i]);

                            IRepair repair = new Repair(partName, hoursWorked);
                            engineer.AddRepair(repair);


                        }

                        soldier = engineer;
                        break;
                    case "Commando":
                        string commandCorps = tokens[5];
                        var commando = new Commando(id, firstName, lastName, salary, commandCorps);
                        for (int i = 6; i < tokens.Length; i++)
                        {
                            string codeName = tokens[i];
                            string missionState = tokens[++i];
                            try
                            {
                                IMission mission = new Mission(codeName, missionState);
                                commando.AddMission(mission);
                            }
                            catch { }
                        }

                        soldier = commando;
                        break;
                    case "Spy":
                        int codeNumber = (int)salary;
                        soldier = new Spy(id, firstName, lastName, codeNumber);
                        break;
                    default:
                        throw new ArgumentException("Invalid soldier type!");
                }
                soldiers.Add(soldier);
            }
            catch{}
            
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }
}
