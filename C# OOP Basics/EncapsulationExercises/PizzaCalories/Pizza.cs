﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pizza
{
    private string name;
    private decimal calories;
    private int toppingCount;

    public Pizza(string name)
    {
        this.Name = name;
        this.Toppings = new List<Topping>();
    }

    public Pizza()
    {

    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public double Calories { get; set; }

    public int ToppingCount
    {
        get => this.toppingCount;
        private set
        {
            if (value < 0 || value > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppingCount = value;
        }
    }

    public Dough Dough { get; set; }
    public List<Topping> Toppings { get; set; }

    public decimal CalcCalories()
    {
        return this.Dough.CalcCalories() + this.Toppings.Sum(t => t.CalcCalories());
    }
}
