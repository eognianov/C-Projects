using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
          public static void Main()
            {
                Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(x => char.IsUpper(x[0]))));
            }
        
    }
}
