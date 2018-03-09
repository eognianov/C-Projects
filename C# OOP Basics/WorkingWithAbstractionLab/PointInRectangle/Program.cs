using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        int[] intupRectangle = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();
        Point topLeft = new Point(intupRectangle[0],intupRectangle[1]);
        Point bottomLeft = new Point(intupRectangle[2],intupRectangle[3]);
        Rectangle rectangle = new Rectangle(topLeft, bottomLeft);
        int pointsToCheck = int.Parse(Console.ReadLine());
        for (int i = 0; i < pointsToCheck; i++)
        {
            int[] pointInput = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Point pointToCheck = new Point(pointInput[0], pointInput[1]);
            Console.WriteLine(rectangle.Contains(pointToCheck));
        }
    }
}

