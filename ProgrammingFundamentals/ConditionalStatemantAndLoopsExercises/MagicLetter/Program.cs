using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char bannedLetter = char.Parse(Console.ReadLine());
            for(char i = firstLetter; i <= secondLetter; i++)
            {
                for (char j = firstLetter; j <= secondLetter; j++)
                {
                    for (char f = firstLetter; f <= secondLetter; f++)
                    {
                        if (i!=bannedLetter && j != bannedLetter && f !=bannedLetter)
                        {
                            Console.Write($"{i}{j}{f} ");
                        }
                    }
                }
            }

        }
    }
}
