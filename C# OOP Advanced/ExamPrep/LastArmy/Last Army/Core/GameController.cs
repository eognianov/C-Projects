using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GameController
{
    private IArmy army;
    private IWareHouse wearHouse;
    private MissionController missionController;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IWriter writer;

    public GameController(IWriter writer)
    {
        this.army = new Army();
        this.wearHouse = new WareHouse();
        this.missionController = new MissionController(army, wearHouse);
        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
        this.writer = writer;
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            if (data[1] == "Regenerate")
            {
                army.RegenerateTeam(data[2]);
            }
            else
            {
                var soldier = soldierFactory.CreateSoldier(data[1], data[2], int.Parse(data[3]), double.Parse(data[4]),
                    double.Parse(data[5]));

                if (wearHouse.TryEquipSoldier(soldier))
                {
                    army.AddSoldier(soldier);
                }
                else
                {
                    throw new ArgumentException(string.Format(OutputMessages.SoldierCannotBeEquiped, data[1], data[2]));
                }
            }
            

        }

        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);

            this.wearHouse.AddAmunition(name,number);
        }
        else if (data[0].Equals("Mission"))
        {
            var mission = missionFactory.CreateMission(data[1], double.Parse(data[2]));
            writer.AppendLine(missionController.PerformMission(mission).Trim());
        }
    }

    public void RequestResult()
    {
        missionController.FailMissionsOnHold();
        writer.AppendLine(OutputMessages.Results);
        writer.AppendLine(string.Format(OutputMessages.SuccessfullMissionsCount, missionController.SuccessMissionCounter));
        writer.AppendLine(string.Format(OutputMessages.FailedMissionsCount, missionController.FailedMissionCounter));
        writer.AppendLine(OutputMessages.Soldiers);

        foreach (var soldier in this.army.Soldiers.OrderByDescending(s=>s.OverallSkill))
        {
            writer.AppendLine(soldier.ToString());
        }

    }
}
