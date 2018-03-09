using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountTheIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int check = 0;
            while (true)
            {
                try
                {
                    check = int.Parse(Console.ReadLine());
                    count++;
                }
                    
                catch
                {
                    Console.WriteLine(count);
                    return;
                }
                    
                    
            }
            

        }
    }
}
