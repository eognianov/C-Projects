using System;
using System.Collections.Generic;
using System.Text;


public interface ICommando:ISpecialisedSoldier
{
    IReadOnlyCollection<IMission> Missions { get; }
    void CompleteMission(string missionCodeName);
    void AddMission(IMission mission);
}



