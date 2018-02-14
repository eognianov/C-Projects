using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    private int age;

    public Person()
    {
        age = 1;
        name = "No name";
    }

    public Person(int age):this()
    {
        this.age = age;
    }

    public Person(int age, string name):this(age)
    {
        this.name = name;
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

}

