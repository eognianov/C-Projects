using System;

namespace EventImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            INameChangeable dispecher = new Dispatcher("Pesho");
            INameChangeHandler handler = new Handler();

            dispecher.NameChange += handler.OnDispecherNameChange;

            string input;
            while ((input=Console.ReadLine())!="End")
            {
                dispecher.Name = input;
            }

        }
    }
}
