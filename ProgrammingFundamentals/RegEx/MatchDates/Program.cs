using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})\b";
            var datesStrings = Console.ReadLine();
            Regex dates = new Regex(regex);
           
            foreach (Match date in dates.Matches(datesStrings))
            {
                var day = date.Groups[1].Value;
                var month = date.Groups[3].Value;
                var year = date.Groups[4].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
