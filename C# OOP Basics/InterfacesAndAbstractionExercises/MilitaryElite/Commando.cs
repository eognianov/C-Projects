﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Commando:SpecialisedSoldier,ICommando
{
    private ICollection<IMission> missions;
    public Commando(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
    {
        this.missions = new List<IMission>();
    }

    public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>) missions;

    public void CompleteMission(string missionCodeName)
    {
        IMission mission = this.Missions.FirstOrDefault(m => m.CodeName == missionCodeName);
        if (mission== null)
        {
            throw new ArgumentException("Mission not found!");
        }
        mission.Complete();
    }

    public void AddMission(IMission mission)
    {
        missions.Add(mission);
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine(base.ToString());
        builder.AppendLine($"{nameof(this.Corps)}: {this.Corps.ToString()}").AppendLine($"{nameof(this.Missions)}:");
        foreach (var mission in Missions)
        {
            builder.AppendLine($"  {mission.ToString()}");
        }

        string result = builder.ToString().TrimEnd();
        return result;
    }
}

    
