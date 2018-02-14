using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Family
{
    private  List<Person> people;

    public Family()
    {
        people = new List<Person>();
    }

    public void AddMember(Person member)
    {
        people.Add(member);
    }

    public Person GetOldesMember()
    {
        Person oldest = people.OrderByDescending(p => p.Age).First();
        return oldest;
    }
}

