using System;


class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        var gandalf = new Gandalf();

        var foods = FoodFactory.ProduceFood(input);
        MoodFactory.ChangeMood(gandalf, foods);

        Console.WriteLine(gandalf);
    }
}
