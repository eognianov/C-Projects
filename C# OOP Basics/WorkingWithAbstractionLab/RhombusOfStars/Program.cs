using System;


class Program
{
    static void Main(string[] args)
    {
        int stars = int.Parse(Console.ReadLine());
        if (stars == 1)
        {
            Console.WriteLine("*");
        }
        else
        {


            for (int counter = 1; counter <= stars; counter++)
            {
                PrintRow(stars, counter);
            }

            for (int counter = stars - 1; counter > 0; counter--)
            {
                PrintRow(stars, counter);
            }
        }
    }

    static void PrintRow(int rhombusSize, int rowSize)
    {
        for (int counter = 0; counter < rhombusSize - rowSize; counter++)
        {
            Console.Write(" ");
        }
        for (int counter = 0; counter < rowSize; counter++)
        {
            Console.Write("* ");
        }
        Console.WriteLine();
    }
}

