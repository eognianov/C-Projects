using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
        for (int i = 0; i < n; i++)
        {
            string[] carInfo = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string model = carInfo[0];
            float fuel = float.Parse(carInfo[1]);
            float fuelConsumption = float.Parse(carInfo[2]);
            int distance = 0;
            cars.Add(new Car(model,fuel,fuelConsumption,distance));
        }
        string[] command = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        while (command[0] != "End")
        {
            string model = command[1];
            int distanceToDrive = int.Parse(command[2]);
            Car currentCar = cars.FirstOrDefault(c => c.Model == model);
            currentCar.Drive(distanceToDrive);
            command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmout:F2} {car.DistanceTraveled}");
        }
    }
}

