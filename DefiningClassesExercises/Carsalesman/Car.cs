using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    private Engine engine;

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    private string weight;

    public string Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    private string color;

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public Car(string model, Engine engine, string weight, string color)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }

    public override string ToString()
    {
        return $"{Model}:" + Environment.NewLine + $"  {Engine}" + Environment.NewLine + $"  Weight: {Weight}" +
               Environment.NewLine + $"  Color: {Color}";
    }
}

