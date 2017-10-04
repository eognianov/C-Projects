using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryCalculator
{
    class Program
    {
        static double GeoCalc(string type)
        {
            double result = 0d;
            switch (type)
            {
                case "triangle":
                    double triangleSide = double.Parse(Console.ReadLine());
                    double triangleHight = double.Parse(Console.ReadLine());
                    result = (triangleSide * triangleHight) / 2;
                    break;
                case "square":
                    double squareSide = double.Parse(Console.ReadLine());
                    result = squareSide * squareSide;
                    break;
                case "rectangle":
                    double rectangleWidth = double.Parse(Console.ReadLine());
                    double rectangleHeight = double.Parse(Console.ReadLine());
                    result = rectangleHeight * rectangleWidth;
                    break;
                case "circle":
                    double circleRadius = double.Parse(Console.ReadLine());
                    result = Math.PI * circleRadius * circleRadius;
                    break;;
            }
            return result;
        }
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            Console.WriteLine($"{GeoCalc(figure):F2}");
            
        }
    }
}
