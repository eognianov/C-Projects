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

    private float fuelAmount;

    public float FuelAmout
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    private float fuelConsumption;

    public float FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    private int distanceTraveled;

    public int DistanceTraveled
    {
        get { return distanceTraveled; }
        set { distanceTraveled = value; }
    }


    public Car(string name, float fuel, float consumption, int distance)
    {
        this.Model = name;
        this.FuelAmout = fuel;
        this.FuelConsumption = consumption;
        this.DistanceTraveled = distance;
    }

    public void Drive(int distance)
    {
        float fuelNeeded = distance * FuelConsumption;
        if (fuelNeeded<=fuelAmount)
        {
            fuelAmount -= fuelNeeded;
            DistanceTraveled += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

}

