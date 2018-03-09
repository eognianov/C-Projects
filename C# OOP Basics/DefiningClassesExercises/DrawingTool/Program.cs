using System;


class Program
{
    static void Main(string[] args)
    {

        var figure = Console.ReadLine();

        if (figure.Equals("Square"))
        {
            Square.DrowSquare(int.Parse(Console.ReadLine()));
        }
        else
        {
            Rectangle.DrowRectangle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        }

    }
}

