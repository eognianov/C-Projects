using System;


class Program
{
    static void Main(string[] args)
    {
        string[] inputData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        decimal pricePerDay = decimal.Parse(inputData[0]);
        int countOfDays = int.Parse(inputData[1]);
        string season = inputData[2];
        string discount = "None";
        if (inputData.Length==4)
        {
            discount = inputData[3];
        }
        PriceCalculator calculator = new PriceCalculator();
        calculator.Calculte(pricePerDay,countOfDays,season,discount);
        Console.WriteLine(calculator);
    }
}

