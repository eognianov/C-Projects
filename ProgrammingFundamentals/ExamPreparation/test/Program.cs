using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
   
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            List<Person> persons = new List<Person>();
            while (true)
            {
                if (inputArgs[0] == "END")
                {
                    break;
                }

                switch (inputArgs[0])
                {
                    case "ADD":
                        string name = inputArgs[1];
                        int age = int.Parse(inputArgs[2]);
                        double cash = double.Parse(inputArgs[3]);
                        Person person = new Person()
                        {
                            Age = age,
                            Name = name,
                            Credit = new List<double>() {cash},
                            Fundz = 0
                        };
                        persons.Add(person);
                        break;
                    case "FUNDZ":
                        string currentName = inputArgs[1];
                        int fundz = int.Parse(inputArgs[2]);
                        
                        Person currentPerson = persons.FirstOrDefault(p => p.Name == currentName);
                        int indexOfPerson = persons.IndexOf(currentPerson);
                        if (persons[indexOfPerson].Credit.Sum() >= fundz * 10)
                        {
                            persons[indexOfPerson].Fundz += fundz;
                            persons[indexOfPerson].Credit.Add(-fundz*10);
                        }
                        else
                        {
                            Console.WriteLine($"{persons[indexOfPerson].Name} nqma dostatuchno pari za {fundz} paketa.");
                        }
                        
                        break;

                }
                inputArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<double> Credit { get; set; }
            public int Fundz { get; set; }

        }
    }

}
