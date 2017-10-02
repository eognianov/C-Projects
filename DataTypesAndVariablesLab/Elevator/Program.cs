using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int maxPeople = int.Parse(Console.ReadLine());
            int courses = (int)Math.Ceiling((double)numberOfPeople / maxPeople);
            Console.WriteLine(courses);
        }
    }
}
