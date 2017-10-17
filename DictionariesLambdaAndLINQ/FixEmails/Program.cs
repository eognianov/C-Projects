using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> allEmailAddres = new Dictionary<string, string>();
            string inputLine = Console.ReadLine();
            while (inputLine != "stop")
            {
                string accountName = inputLine;
                string emailAddres = Console.ReadLine();
                string[] emailDomeinCheck = emailAddres.ToLower().Split('.').ToArray();
                if (emailDomeinCheck[1] != "us" && emailDomeinCheck[1] != "uk")
                {
                    allEmailAddres.Add(accountName,emailAddres);
                   
                }
                inputLine = Console.ReadLine();
            }
            foreach (var user in allEmailAddres) 
            {
                Console.WriteLine($"{user.Key} -> {user.Value}");
            }
        }
    }
}
