using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionofCircles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] circleOneInfo = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            int[] circleTwoInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            Point circleOneCenter = new Point(){X = circleOneInfo[0], Y =circleOneInfo[1]};
            Point circleTwoCenter = new Point() { X = circleTwoInfo[0], Y = circleTwoInfo[1] };
            Circle circleOne = new Circle(){Center = circleOneCenter,Radius = circleOneInfo[2]};
            Circle circleTwo = new Circle() { Center = circleTwoCenter, Radius = circleTwoInfo[2] };
            if (Intersect(circleOne,circleTwo))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }

        static bool Intersect(Circle c1, Circle c2)
        {
            double d = CalcDistance(c1.Center, c2.Center);
            return d <= (c1.Radius + c2.Radius);
        }

        static double CalcDistance(Point p1, Point p2)
        {
            int deltaX = p2.X - p1.X;
            int deltaY = p2.Y - p1.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public class Circle
        {
            public Point Center { get; set; }
            public int Radius { get; set; }
            
        }
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
