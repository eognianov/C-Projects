using System;
using System.Collections.Generic;
using System.Text;


public abstract class SpecialisedSoldier:Private,ISpecialisedSoldier
{
    public  SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
    {
        ParseCorps(corps);
    }

    private void ParseCorps(string corps)
    {
        bool validCorps = Enum.TryParse(typeof(Corps), corps, out object outCorps);
        if (!validCorps)
        {
            throw new  ArgumentException("Invalid corps!");
        }

        this.Corps = (global::Corps) outCorps;
        
    }

    public Corps Corps { get; private set; }
}

