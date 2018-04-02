using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Stealer;


public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
        {
            foreach (var attribute in method.GetCustomAttributes<SoftUniAttribute>())
            {
                Console.WriteLine(attribute.Name);
            }
        }
    }
}

