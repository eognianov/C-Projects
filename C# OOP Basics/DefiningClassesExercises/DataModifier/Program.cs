using System;


class Program
{
    static void Main(string[] args)
    {
        var firstDateAsStr = Console.ReadLine();
        var secondDateAsStr = Console.ReadLine();

        Console.WriteLine(DateModifier.GetDaysBetweenTwoDates(firstDateAsStr, secondDateAsStr));
    }
}

