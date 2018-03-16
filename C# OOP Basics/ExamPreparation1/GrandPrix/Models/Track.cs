using System;
using System.Collections.Generic;
using System.Text;


public class Track
{



    public Track(int lapsNumber, int trackLength)
    {
        this.LapsNumber = lapsNumber;
        this.TrackLenght = trackLength;
        this.Weather = Weather.Sunny;
        this.CurrentLap = 0;
    }

    private Weather weather;

    public Weather Weather
    {
        get { return weather; }
        set { weather = value; }
    }
    
    public int CurrentLap { get; set; }
    public int LapsNumber { get; }
    public int TrackLenght { get;}
}

