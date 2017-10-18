using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingTheBuilt_in.NETClasses
{
    class Program
    {
         public static void Main(string[] args)
         {
            //string inputDate = Console.ReadLine();
            //var output = DateTime.ParseExact(inputDate, "d-M-yyyy", CultureInfo.InvariantCulture);
            //Console.WriteLine(output.DayOfWeek);
             int[] inputDate = Console.ReadLine()
                .Split(new char[] {'-'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse) 
                .ToArray();
             var day = new DateTime(inputDate[2], inputDate[1], inputDate[0]);
             Console.WriteLine(day.DayOfWeek);
         }
    } 
}
