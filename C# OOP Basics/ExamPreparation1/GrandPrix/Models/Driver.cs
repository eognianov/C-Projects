using System;
using System.Collections.Generic;
using System.Text;


public abstract class Driver
{
    private const double BOX_DEFAULT_TIME = 20;

    protected Driver(string name, Car car, double fuelConsumption)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumption;
        this.TotalTime = 0d;
    }

    public string Name { get; }

    public double TotalTime { get; private set; }

    public Car Car { get; }

    public double FuelConsumptionPerKm { get; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public string FailureReason { get; private set; }

    public bool IsRacing { get; private set; }

    private string Status => IsRacing ? this.TotalTime.ToString() : this.FailureReason;

    private void Box()
    {
        this.TotalTime += BOX_DEFAULT_TIME;
    }

    public void Refuel(string[] methodArgs)
    {
        this.Box();

        double fuelAmount = double.Parse(methodArgs[0]);

        this.Car.Refuel(fuelAmount);
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Box();

        this.Car.ChangeTyres(tyre);
    }

    public void CompleteLap(int trackLengnt)
    {
        this.TotalTime += 60 / (trackLengnt / this.Speed);

        this.Car.CompleteLap(trackLengnt, this.FuelConsumptionPerKm);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Status}";
    }


    public void Fail(string message)
    {
        this.IsRacing = false;
        this.FailureReason = message;
    }
}

