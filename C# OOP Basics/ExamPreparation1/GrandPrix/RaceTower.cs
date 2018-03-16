using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


public class RaceTower
{
    private const string CrashReason = "Crash";
    private IList<Driver> racingDrivers;
    private Stack<Driver> failedDrivers;
    private Track track;    

    public RaceTower()
    {
        this.racingDrivers = new List<Driver>();
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            string driverType = commandArgs[0];
            string driverName = commandArgs[1];

            int horsePower = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);

            string[] tyreArgs = commandArgs.Skip(4).ToArray();



            Tyre tyre = CreateTyre(tyreArgs);

            Car car = new Car(horsePower, fuelAmount, tyre);

            Driver driver = CreateDriver(driverType, driverName, car);

            racingDrivers.Add(driver);
        }
        catch { }

    }

    private Driver CreateDriver(string type, string name, Car car)
    {
        Driver driver = null;
        if (type=="Aggressive")
        {
           driver = new AggressiveDriver(name,car);
        }
        else if (type == "Endurance")
        {
            driver = new EnduranceDriver(name, car);
        }

        if (driver==null)
        {
            throw new ArgumentException(ErrorMessages.InvalidDriverType);
        }

        return driver;
    }

    private Tyre CreateTyre(string[] tyreArgs)
    {
        string tyreType = tyreArgs[0];
        double tyreHardness = double.Parse(tyreArgs[1]);

        Tyre tyre = null;

        if (tyreType =="Hard")
        {
            tyre = new HardTyre(tyreHardness);
        }
        else if (tyreType == "Ultrasoft")
        {
            double grip = double.Parse(tyreArgs[2]);
            tyre = new UltrasoftTyre(tyreHardness, grip);
        }

        if (tyre==null)
        {
            throw new ArgumentException(ErrorMessages.InvalidTyreType);
        }
        return tyre;
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string boxReason = commandArgs[0];
        string driverName = commandArgs[1];

        Driver driver = this.racingDrivers.FirstOrDefault(d => d.Name == driverName);

        string[] methodArgs = commandArgs.Skip(2).ToArray();
        if (boxReason=="Refuel")
        {
            driver.Refuel(methodArgs);
        }
        else if (boxReason == "ChangeTyres")
        {
            Tyre tyre = CreateTyre(methodArgs);
            driver.ChangeTyres(tyre);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int numberOfLaps = int.Parse(commandArgs[0]);

        if (numberOfLaps>this.track.LapsNumber-this.track.CurrentLap)
        {
            throw new ArgumentException(string.Format(ErrorMessages.InvalidLaps, track.CurrentLap));
        }

        for (int index = 0; index < this.racingDrivers.Count; index++)
        {
            Driver driver = racingDrivers[index];
            try
            {

            driver.CompleteLap(this.track.TrackLenght);
            }
            catch (ArgumentException e)
            {
                driver.Fail(e.Message);
                this.failedDrivers.Push(driver);
                this.racingDrivers.RemoveAt(index);
                index--;
            }
        }

        var orderedDrivers = this.racingDrivers.OrderByDescending(d => d.TotalTime).ToArray();

        for (int i = 0; i < orderedDrivers.Length-1; i++)
        {
            Driver overtakingDriver = orderedDrivers[i];
            Driver targerDriver = orderedDrivers[i + 1];

            bool overTakeHappened = this.TryOverTake(overtakingDriver, targerDriver);
        }
    }

    private bool TryOverTake(Driver overtakingDriver, Driver targerDriver)
    {
        double timediff = overtakingDriver.TotalTime - targerDriver.TotalTime;
        bool succsses = false;
        if (timediff<=3)
        {
            bool aggressiveDriver = overtakingDriver is AggressiveDriver && overtakingDriver.Car.Tyre is UltrasoftTyre;
            bool enduranceDriver = overtakingDriver is EnduranceDriver && overtakingDriver.Car.Tyre is HardTyre;
            if (aggressiveDriver)
            {
                if (this.track.Weather == Weather.Foggy)
                {
                    overtakingDriver.Fail(CrashReason);
                }

                succsses = true;
            }
            else if (enduranceDriver)
            {
                if (this.track.Weather==Weather.Rainy)
                {
                    overtakingDriver.Fail(CrashReason);
                }

                succsses = true;
            }
        }
        else if (timediff<=2)
        {
            
        }
    }

    public string GetLeaderboard()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Lap {this.track.CurrentLap}/{this.track.LapsNumber}");

        var leaderBoardDrivers = racingDrivers
            .OrderBy(d => d.TotalTime).Concat(this.failedDrivers);

        int position = 1;

        foreach (var driver in leaderBoardDrivers)
        {
            builder.AppendLine($"{position} {driver.ToString()}");
            position++;
            
        }
        string result = builder.ToString().TrimEnd();
        return result;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string weatherType = commandArgs[0];
        bool validWeather = Enum.TryParse(typeof(Weather), weatherType, out object weatherObj);
        if (!validWeather)
        {
            throw new ArgumentException(ErrorMessages.InvalidWeatherType);
        }
        Weather weather = (Weather)weatherObj;
        this.track.Weather = weather;

    }
}

