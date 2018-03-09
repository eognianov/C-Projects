using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsPerGreenLight = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();
            var carsQueue = new Queue<string>();
            int counter = 0;
            while (input != "end")
            {
                if (input == "green")
                {
                    var carsThatCanPass = Math.Min(carsPerGreenLight, carsQueue.Count);
                    for (int i = 0; i < carsThatCanPass; i++)
                    {
                        counter++;
                        Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                    }
                    
                }
                if (input != "green")
                    carsQueue.Enqueue(input);
                input = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
