using System;
using System.Collections.Generic;
using System.Text;


public class Animal : ISoundProducable
{
    private const string ERROR_MESSAGE = "Invalid input!";
    private string name;
    private int age;
    private string gander;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ERROR_MESSAGE);
            }
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value<0)
            {
                throw new ArgumentException(ERROR_MESSAGE);
            }
            age = value;
        }
    }

    public string Gander
    {
        get { return gander; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ERROR_MESSAGE);
            }
            if (value !="Male" && value!="Female")
            {
                throw new ArgumentException(ERROR_MESSAGE);
            }
            gander = value;
        }
    }

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gander = gender;
    }

    public virtual string ProduceSound()
    {
        return "NOISE.....";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name}")
            .AppendLine($"{this.Name} {this.Age} {this.Gander}")
            .AppendLine(this.ProduceSound());
        return sb.ToString().TrimEnd();

    }
}

