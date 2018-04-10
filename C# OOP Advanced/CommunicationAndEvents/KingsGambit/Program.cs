using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IKing king = SetupKing();
        Engine engine = new Engine(king);
        engine.Run();
    }

    private static IKing SetupKing()
    {
        string kingName = Console.ReadLine();
        IKing king = new King(kingName, new List<ISubordinate>());

        string[] royalGourdNames = Console.ReadLine().Split();

        foreach (var name in royalGourdNames)
        {
            king.AddSubordinate(new RoyalGaurd(name));
        }

        string[] footmanNames = Console.ReadLine().Split();

        foreach (var name in footmanNames)
        {
            king.AddSubordinate(new Footman(name));
        }

        return king;
    }
}

