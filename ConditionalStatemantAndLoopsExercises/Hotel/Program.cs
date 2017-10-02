using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string mounth = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double studioPrice = 0;
            double doublePrice = 0;
            double SuitePrice = 0;
            switch (mounth)
            {
                case "May":
                case "October":
                    studioPrice = 50;
                    doublePrice = 65;
                    SuitePrice = 75;
                    if (days>7)
                    {
                        studioPrice = 47.5;
                    }
                    break;
                case "June":
                case "September":
                    studioPrice = 60;
                    doublePrice = 72;
                    SuitePrice = 82;
                    if (days > 14)
                    {
                        doublePrice = 64.8;
                    }
                    break;
                case "July":
                case "August":
                case "December":
                    studioPrice = 68;
                    doublePrice = 77;
                    SuitePrice = 89;
                    if (days > 14)
                    {
                        SuitePrice = 75.65;
                    }
                    break;
            }
            doublePrice *= days;
            SuitePrice *= days;
            if ((mounth=="September" || mounth =="Octomber") && (days >7))
            {
                studioPrice *= (days - 1);
            }
            else
            {
                studioPrice *= days;
            }
            Console.WriteLine($"Studio: {studioPrice:F2} lv."+Environment.NewLine+ $"Double: {doublePrice:F2} lv." + Environment.NewLine + $"Suite: {SuitePrice:F2} lv.");
        }
    }
}
