using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greetings
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string LastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine($"Hello, {firstName} {LastName}. You are {age} years old.");
        }
    }
}
