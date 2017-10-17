using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            Dictionary<string, long> resourseBalance = new Dictionary<string, long>();
            while (inputLine != "stop")
            {
                string resource = inputLine;
                long quantity = long.Parse(Console.ReadLine());
                if (resourseBalance.ContainsKey(resource))
                {
                    resourseBalance[resource] += quantity;
                }
                else
                {
                    resourseBalance.Add(resource, quantity);
                }

                inputLine = Console.ReadLine();
            }
            foreach (var resuorce in resourseBalance)
            {
                Console.WriteLine($"{resuorce.Key} -> {resuorce.Value}");
            }
        }
    }
}