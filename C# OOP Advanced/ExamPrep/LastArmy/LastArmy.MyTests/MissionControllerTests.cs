using System;
using NUnit.Framework;

namespace LastArmy.MyTests
{
    public class MissionControllerTests
    {
        [Test]
        public void MissionCtrollerDisplaysFailMessage()
        {
            var army = new Army();
            var wareHourse = new WareHouse();
            var missionController = new MissionController(army, wareHourse);

            var mission = new Easy(1);
            string result="";
            for (int i = 0; i < 4; i++)
            {
                result=missionController.PerformMission(mission);
            }

            Assert.IsTrue(result.StartsWith("Mission declined"));
        }

        [Test]
        public void MissionCtrollerDisplaysSuccessMessage()
        {
            var army = new Army();
            var wareHourse = new WareHouse();
            var missionController = new MissionController(army, wareHourse);

            var mission = new Easy(0);
            string result =result = missionController.PerformMission(mission);
            

            Assert.IsTrue(result.StartsWith("Mission completed"));
        }
    }
}
