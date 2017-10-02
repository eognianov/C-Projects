using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleProparties
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double diagonal = Math.Sqrt((width * width) + (height * height));
            Console.WriteLine(width + width + height + height);
            Console.WriteLine(width * height);
            Console.WriteLine(diagonal);
        }
    }
}
