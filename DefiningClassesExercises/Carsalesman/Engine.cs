using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


public class Engine
{
    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    private string power;

    public string Power
    {
        get { return power; }
        set { power = value; }
    }

    private string dispalcement;

    public string Displacement
    {
        get { return dispalcement; }
        set { dispalcement = value; }
    }

    private string efficiency;

    public string Efficiency
    {
        get { return efficiency; }
        set { efficiency = value; }
    }


    public Engine(string model, string power, string dispalcement, string efficiency)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = dispalcement;
        this.Efficiency = efficiency;
    }

    public override string ToString()
    {
        return $"{Model}:" + Environment.NewLine + $"    Power: {Power}" + Environment.NewLine + $"    Displacement: {Displacement}" + Environment.NewLine + $"    Efficiency: {Efficiency}";
    }
}

