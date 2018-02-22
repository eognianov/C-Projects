using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        string[] peopleInput = Console.ReadLine().Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
        string[] productsInput = Console.ReadLine().Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
        List<Person> people = new List<Person>();
        foreach (var personInput in peopleInput)
        {
            string[] tokkens = personInput.Split(new char[] {'='}, StringSplitOptions.RemoveEmptyEntries);
            string personName = tokkens[0];
            decimal personMoney = decimal.Parse(tokkens[1]);
            try
            {
                Person person = new Person(personName, personMoney);
                people.Add(person);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                return;
            }
            
        }
        List<Product> products = new List<Product>();
        foreach (var productInput in productsInput)
        {
            string[] tokkens = productInput.Split(new char[] {'='}, StringSplitOptions.RemoveEmptyEntries);
            string productName = tokkens[0];
            decimal productPrice = decimal.Parse(tokkens[1]);
            try
            {
                Product product = new Product(productName, productPrice);
                products.Add(product);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                return;
            }
            
        }

        string command;
        while ((command=Console.ReadLine())!="END")
        {
            string[] tokkens = command.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string personName = tokkens[0];
            string productName = tokkens[1];
            Person person = people.First(p => p.Name == personName);
            Product product = products.First(p => p.Name == productName);
            string output = person.TryBuyProduct(product);
            Console.WriteLine(output);
        }
        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }
}

