using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class MissionFactory:IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == difficultyLevel);
        return (IMission) Activator.CreateInstance(type, neededPoints);
    }
}
