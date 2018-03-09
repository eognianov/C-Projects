using System;
using System.Linq;
using System.Reflection;


class Program
{
    public static void Main()
    {
        try
        {
            

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            var box = new Box(length, width, height);
            Console.WriteLine(box);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

