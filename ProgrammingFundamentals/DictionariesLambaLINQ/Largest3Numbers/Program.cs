using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            
            if (intputNumbers.Count <= 3)
            {
                Console.WriteLine(string.Join(" ",intputNumbers.OrderByDescending(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join(" ",intputNumbers.OrderByDescending(x => x).Take(3)));
            }
        }
    }
}
