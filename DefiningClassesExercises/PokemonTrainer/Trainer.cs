using System;
using System.Collections.Generic;
using System.Text;


public class Trainer
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int numberOfBadges;

    public int NumberOfBadges
    {
        get { return numberOfBadges; }
        set { numberOfBadges = value; }
    }

    private List<Pokemon> pokemons;

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    public Trainer()
    {
        numberOfBadges = 0;
        Pokemons = new List<Pokemon>();
    }

    public Trainer(string name,Pokemon pokemon):this()
    {
        this.Name = name;
        this.Pokemons.Add(pokemon);   
    }
}

