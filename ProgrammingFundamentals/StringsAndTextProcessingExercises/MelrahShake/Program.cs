using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelrahShake
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();
            int firstIndex = input.IndexOf(pattern);
            int lastIndex = input.LastIndexOf(pattern);
            while (firstIndex>=0 && lastIndex>=0 && firstIndex != lastIndex && pattern.Length>0)
            {
                input = input.Remove(lastIndex, pattern.Length);
                input = input.Remove(firstIndex, pattern.Length);
                Console.WriteLine("Shaked it.");
                pattern = pattern.Remove(pattern.Length / 2,1);
                firstIndex = input.IndexOf(pattern);
                lastIndex = input.LastIndexOf(pattern);
                
            }
            Console.WriteLine("No shake.");
            Console.WriteLine(input);
        }

    }
}
