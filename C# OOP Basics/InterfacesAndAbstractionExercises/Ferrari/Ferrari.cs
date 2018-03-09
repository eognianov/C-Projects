using System;
using System.Collections.Generic;
using System.Text;


class Ferrari:ICar
{
    public string Model { get; set; }
    public string Driver { get; set; }

    public string UseBreaks()
    {
        return "Brakes!";
    }

    public string PushTheGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public Ferrari(string driver)
    {
        this.Model = "488-Spider";
        this.Driver = driver;
    }

    public override string ToString()
    {
        return $"{Model}/{UseBreaks()}/{PushTheGasPedal()}/{Driver}";
    }
}

