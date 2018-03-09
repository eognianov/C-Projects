using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace RectanglePosition
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r1 = ReadRectangle(), r2 = ReadRectangle();
            Console.WriteLine(r1.IsInside(r2) ? "Inside" : "Not inside");
        }

        public class Rectangle
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public int Right
            {
                get { return Left + Width; }
            }

            public int Bottom
            {
                get { return Top + Height; }
            }

            public bool IsInside(Rectangle other)
            {
                var isInLeft = Left >= other.Left;
                var isInRight = Right <= other.Right;
                var isInsideHorizontal = isInLeft && isInRight;
                var isInTop = Top >= other.Top;
                var isInBottom = Bottom <= other.Bottom;
                var isInsideVertical = isInTop && isInBottom;
                return isInsideHorizontal && isInsideVertical;
            }
        }
        public static Rectangle ReadRectangle()
        {
            var size = Console.ReadLine().Split().Select(int.Parse);
            Rectangle rectangle = new Rectangle()
            {
                Left = size.First(),
                Top = size.Skip(1).First(),
                Width = size.Skip(2).First(),
                Height = size.Skip(3).First()
            };
            return rectangle;
        }
    }
}
