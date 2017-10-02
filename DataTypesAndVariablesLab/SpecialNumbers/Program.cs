using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int num = i;
                string check = "";
                while (num != 0)
                {
                    sum += num % 10;
                    num = num / 10;
                }
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    check = "True";
                }
                else
                {
                    check = "False";
                }
                Console.WriteLine($"{i} - > {check}");
            }

        }
    }
}
