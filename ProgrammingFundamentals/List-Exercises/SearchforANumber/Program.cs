using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchforANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] inputCommands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> resultNumbers = inputNumbers.Take(inputCommands[0]).ToList();
            resultNumbers.RemoveRange(0,inputCommands[1]);
            if (resultNumbers.Contains(inputCommands[2]))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
            

        }
    }
}
