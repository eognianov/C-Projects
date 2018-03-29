using System;
using System.Collections.Generic;
using System.Text;


public class PersonNameComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Name.Length.CompareTo(y.Name.Length);

        if (result == 0)
        {
            result = char.ToLower(x.Name[0]).CompareTo(char.ToLower(y.Name[0]));
        }

        return result;
    }
}

