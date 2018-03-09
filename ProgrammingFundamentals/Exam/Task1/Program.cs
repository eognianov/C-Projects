using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int secyrityKey = int.Parse(Console.ReadLine());
            List<string> affectedSites = new List<string>();
            decimal totalLoss = 0;
            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string siteName = inputData[0];
                uint siteVisits = uint.Parse(inputData[1]);
                decimal siteCommercialPricePerVisit = decimal.Parse(inputData[2]);
                decimal siteLoss = siteVisits * siteCommercialPricePerVisit;
                totalLoss += siteLoss;
                affectedSites.Add(siteName);
                

            }
            Console.WriteLine(string.Join(Environment.NewLine, affectedSites));
            Console.WriteLine($"Total Loss: {totalLoss:F20}");
            decimal securityToken = Convert.ToDecimal(secyrityKey);
            StringBuilder security = new StringBuilder();
            for (int i = 0; i < affectedSites.Count; i++)
            {
                securityToken *= securityToken;
            }
            Console.WriteLine($"Security Token: {securityToken}");
            
        }
        public static decimal DecimalPower(decimal x, decimal y)
        {
            Double X = (double)x;
            Double Y = (double)y;
            return (decimal)System.Math.Pow(X, Y);
        }
        static decimal Power(decimal d, int p)
        {
            if (p == 0) return 1m;
            decimal power = 1m;
            int q = Math.Abs(p);
            for (int i = 1; i <= q; i++) power *= d;
            if (p == q)
                return power;
            return 1m / power;
        }
    }


}
