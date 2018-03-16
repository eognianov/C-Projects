using System;
using System.Collections.Generic;
using System.Text;


public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirment = double.Parse(arguments[3]);
        switch (type)
        {
            case "Hummer":
                return new HammerHarvester(id, oreOutput, energyRequirment);
            case "Sonic":
                return new SonicHarvester(id, oreOutput, energyRequirment, int.Parse(arguments[4]));
            default:
                throw new ArgumentException();
        }
    }
}

