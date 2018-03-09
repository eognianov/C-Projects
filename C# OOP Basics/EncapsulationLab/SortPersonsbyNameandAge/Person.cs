using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string firstName;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (value?.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols");
            }
            firstName = value;
        }
    }

    private string lastName;

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (value?.Length < 3)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols");
            }
            lastName = value;
        }
    }

    private int age;

    public int Age
    {
        get { return age; }
        set
        {
            if (value<=0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            age = value;
        }
    }
    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (value<460)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }
            salary = value;
        }
    }

        
    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;

    }

    public Person(string firstName, string lastName, int age, decimal salary):this(firstName,lastName,age)
    {
        this.Salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (this.Age>30)
        {
            salary = salary + salary * (percentage / 100);
        }
        else
        {
            salary = salary + salary * (percentage / 200);
        }
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} receives {Salary:F2} leva.";
    }
}   

