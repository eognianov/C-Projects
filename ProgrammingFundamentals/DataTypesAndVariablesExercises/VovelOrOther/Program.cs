using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VovelOrOther
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int asciiCode = (int)char.Parse(Console.ReadLine());
            if (48<=asciiCode && asciiCode <=57)
            {
                Console.WriteLine("digit");
            }
            else if (asciiCode == 97 || asciiCode == 101 || asciiCode == 105 || asciiCode == 111 || asciiCode == 117 || asciiCode == 121)
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
            
            
        }
    }
}
