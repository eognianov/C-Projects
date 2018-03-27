using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBox
{
    class Program
    {
        public static void Main()
        {
            //TaskCustomList();
            //TaskTuple();
            TaskThreeuple();
        }

        private static void TaskCustomList()
        {
            CustomList<string> list = new CustomList<string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArgs = input.Split();
                string command = commandArgs[0];

                switch (command)
                {
                    case "Add":
                        list.Add(commandArgs[1]);
                        break;
                    case "Remove":
                        int index = int.Parse(commandArgs[1]);
                        list.Remove(index);
                        break;
                    case "Contains":
                        bool result = list.Contains(commandArgs[1]);
                        Console.WriteLine(result);
                        break;
                    case "Swap":
                        int firtIndex = int.Parse(commandArgs[1]);
                        int secondIndex = int.Parse(commandArgs[2]);
                        list.Swap(firtIndex, secondIndex);
                        break;
                    case "Greater":
                        int count = list.CountGreaterThan(commandArgs[1]);
                        Console.WriteLine(count);
                        break;
                    case "Min":
                        string minElement = list.Min();
                        Console.WriteLine(minElement);
                        break;
                    case "Max":
                        string maxElement = list.Max();
                        Console.WriteLine(maxElement);
                        break;
                    case "Print":
                        for (int i = 0; i < list.Count; i++)
                        {
                            Console.WriteLine(list[i]);
                        }

                        break;
                    case "Sort":
                        list.Sort();
                        break;
                }
            }
        }

        public static void TaskTuple()
        {
            var input = Console.ReadLine().Split();
            var name = $"{input[0]} {input[1]}";
            var address = input[2];

            Console.WriteLine(new Tuple<string, string>(name, address));

            input = Console.ReadLine().Split();
            name = input[0];
            var litersOfBeer = int.Parse(input[1]);

            Console.WriteLine(new Tuple<string, int>(name, litersOfBeer));

            input = Console.ReadLine().Split();
            var integer = int.Parse(input[0]);
            var doubleValue = double.Parse(input[1]);

            Console.WriteLine(new Tuple<int, double>(integer, doubleValue));
        }

        public static void TaskThreeuple()
        {
            var input = Console.ReadLine().Split();
            Console.WriteLine(new Threeuple<string, string, string>($"{input[0]} {input[1]}", input[2], input[3]));

            input = Console.ReadLine().Split();
            var drunkResult = !input[2].Equals("drunk") ? "False" : "True";
            Console.WriteLine(new Threeuple<string, int, bool>(input[0], int.Parse(input[1]), bool.Parse(drunkResult)));

            input = Console.ReadLine().Split();

            Console.WriteLine(new Threeuple<string, double, string>(input[0], double.Parse(input[1]), input[2]));
        }
    }
}
