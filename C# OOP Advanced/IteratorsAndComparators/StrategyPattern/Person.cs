using System;
using System.Collections.Generic;
using System.Text;


public class Person:IComparable<Person>
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;     
    }

    public string Name { get; set; }

    public int Age { get; set; }  

    public int CompareTo(Person other)
    {
        int result = this.Name.CompareTo(other.Name);

        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }

        return result;
    }

    public override string ToString()
    {
        return $"{Name} {Age}";
    }
}

