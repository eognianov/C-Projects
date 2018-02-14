﻿using System;
using System.Collections.Generic;
using System.Text;

public class Employee
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    private string position;

    public string Position
    {
        get { return position; }
        set { position = value; }
    }

    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Employee(string name, string position, decimal salary, int age = -1, string email = "n/a" )
    {
        this.Name = name;
        this.Position = position;
        this.Salary = salary;
        this.Age = age;
        this.Email = email;
    }

}

