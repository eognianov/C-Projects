using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            Dictionary<string,string> phonebook = new Dictionary<string, string>();
            while (inputLine != "END")
            {
                string[] commands = inputLine.Split(' ').ToArray();
                switch (commands[0])
                {
                    case "A":
                        if (phonebook.ContainsKey(commands[1]))
                        {
                            phonebook[commands[1]] = commands[2];
                        }
                        else
                        {
                            phonebook.Add(commands[1], commands[2]);

                        }
                        break;
                    case "S":
                        if (phonebook.ContainsKey(commands[1]))
                        {
                            Console.WriteLine($"{commands[1]} -> {phonebook[commands[1]]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {commands[1]} does not exist.");
                        }
                        break;
                }
                inputLine = Console.ReadLine();
            }
        }
    }
}
