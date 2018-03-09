using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfCities = new Dictionary<string, CityWheather>();
            var pattern = new Regex(@"([A-Z][A-Z])(\d{2}\.\d{1,})(\w+\w)\|");
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                foreach (Match match in pattern.Matches(input))
                {
                    string name = match.Groups[1].Value;
                    var city = new CityWheather()
                    {
                        temperature = (double.Parse(match.Groups[2].Value)),
                        wheather = match.Groups[3].Value
                    };
                    listOfCities[name] = (city);
                }
            }
            var ordered = listOfCities.OrderBy(c => c.Value.temperature);
            foreach (var city in ordered)
            {
                Console.WriteLine($"{city.Key} => {city.Value.temperature:f2} => {city.Value.wheather}");
            }
        }
    }
    public class CityWheather
    {
        public double temperature { get; set; }
        public string wheather { get; set; }

    }
}

