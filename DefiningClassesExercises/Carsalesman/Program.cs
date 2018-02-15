using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int engineCounter = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();
        List<Car> cars = new List<Car>();
        for (int i = 0; i < engineCounter; i++)
        {
            string[] engineData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string model = engineData[0];
            string power = engineData[1];
            string displacement = "n/a";
            string efficiency = "n/a";
            if (engineData.Length == 4)
            {
                displacement = engineData[2];
                efficiency = engineData[3];
            }
            else if (engineData.Length==3)
            {
                bool isItDisplacement = int.TryParse(engineData[2], out _);
                if (isItDisplacement)
                {
                    displacement = engineData[2];
                }
                else
                {
                    efficiency = engineData[2];
                }
            }
            engines.Add(new Engine(model,power,displacement,efficiency));
        }
        int carCounter = int.Parse(Console.ReadLine());
        for (int i = 0; i < carCounter; i++)
        {
            string[] carData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string model = carData[0];
            string engineName = carData[1];
            string weight = "n/a";
            string color = "n/a";
            if (carData.Length == 4)
            {
                weight = carData[2];
                color = carData[3];
            }
            else if (carData.Length == 3)
            {
                bool isAWeight = int.TryParse(carData[2], out _);
                if (isAWeight)
                {
                    weight = carData[2];
                }
                else
                {
                    color = carData[2];
                }
            }
            Engine carEngine = engines.FirstOrDefault(e => e.Model == engineName);
            cars.Add(new Car(model, carEngine, weight, color));
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}

