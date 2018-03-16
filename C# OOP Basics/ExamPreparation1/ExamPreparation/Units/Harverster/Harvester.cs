using System;
using System.Collections.Generic;
using System.Text;


public abstract class Harvester:Unit
{
    private double oreOutput;

    public double OreOutput
    {
        get { return oreOutput; }
        private set
        {
            if (value<0)
            {
                throw new ArgumentException("Harvester is not registerd, because of it's OreOutput");
            }
            oreOutput = value;
        }
    }

    private double energyRequirement;

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        private set
        {
            if (value < 0 || value>20_000)
            {
                throw new ArgumentException("Harvester is not registerd, because of it's EnergyRequirement");
            }
            energyRequirement = value;
        }
    }


    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }

    public override string ToString()
    {
        return $"{Type} Harvester - {Id}" + Environment.NewLine + $"Ore Output: {OreOutput}" + Environment.NewLine + $"Energy Requirement: {EnergyRequirement}";
    }
}

