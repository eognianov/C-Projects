using System;
using System.Collections.Generic;
using System.Text;


public abstract class Soldier:ISoldier
{
    public Soldier(int id, string firstName, string lastName)
    {
        this.Id = id;
        this.FisrtName = firstName;
        this.LastName = lastName;
    }
    public int Id { get; private set; }
    public string FisrtName { get; private set; }
    public string LastName { get; private set; }

    public override string ToString()
    {
        return $"Name: {FisrtName} {LastName} Id: {Id}";
    }
}

