using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private const double maxFuel = 160;
    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public double FuelAmount
    {
        get { return this.fuelAmount;}
        private set
        {
            if (value<0)
            {
                throw new ArgumentException(ErrorMessages.OutOfFuel);
            }

            this.fuelAmount = Math.Min(value, maxFuel);
        }
    }

    public Tyre Tyre { get; private set; }

    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void CompleteLap(int trackLengnt, double fuelConsumption)
    {
        this.FuelAmount -= trackLengnt * fuelConsumption;

        this.Tyre.CompleteLap();
    }
}

