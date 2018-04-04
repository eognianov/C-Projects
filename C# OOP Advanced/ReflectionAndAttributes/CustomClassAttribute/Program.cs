using System;
using System.Linq;

namespace CustomClassAttribute
{
    class Program
    {
        public static void Main()
        {
            CustomAttribute attribute = (CustomAttribute)typeof(Program).GetCustomAttributes(false).FirstOrDefault();

            var input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                Console.WriteLine(attribute.Print(input));

                input = Console.ReadLine();
            }
        }
    }
}
