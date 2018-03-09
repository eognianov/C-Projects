using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = new string[7];
            days[0] = "Monday";
            days[1] = "Tuesday";
            days[2] = "Wednesday";
            days[3] = "Thursday";
            days[4] = "Friday";
            days[5] = "Saturday";
            days[6] = "Sunday";
            int day = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(days[day-1]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
