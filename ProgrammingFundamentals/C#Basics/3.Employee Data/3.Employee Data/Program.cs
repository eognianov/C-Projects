using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            var Name = Console.ReadLine();
            var Age = Console.ReadLine();
            var id = int.Parse(Console.ReadLine());
            var salary = double.Parse(Console.ReadLine());
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Employee ID: {0:D8}", id);
            Console.WriteLine("Salary: {0:F2}", salary);

        }
    }
}
