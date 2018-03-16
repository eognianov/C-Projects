using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        string input;
        var drafManager = new DraftManager();
        while ((input = Console.ReadLine()) != "Shutdown")
        {
            var argumenst = input.Split().ToList();
            var command = argumenst[0];
            argumenst = argumenst.Skip(1).ToList();

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(drafManager.RegisterHarvester(argumenst));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(drafManager.RegisterProvider(argumenst));
                    break;
                case "Day":
                    Console.WriteLine(drafManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(drafManager.Mode(argumenst));
                    break;
                case "Check":
                    Console.WriteLine(drafManager.Check(argumenst));
                    break;

            }
        }

        Console.WriteLine(drafManager.ShutDown());
    }
}

