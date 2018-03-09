using System;
using System.Collections.Generic;
using System.IO;
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
            string[] inputDate = File.ReadAllLines("../../input.txt");
            for (int i = 0; i < inputDate.Length - 1; i+=2)
            {
                string accountName = inputDate[i];
                string emailAddres = inputDate[i + 1];
                string[] emailDomeinCheck = emailAddres.ToLower().Split('.').ToArray();
                if (emailDomeinCheck[1] != "us" && emailDomeinCheck[1] != "uk")
                {
                    allEmailAddres.Add(accountName, emailAddres);
                }
            }
            File.WriteAllText("../../output.txt", "");
            foreach (var account in allEmailAddres)
            {
                File.AppendAllText("../../output.txt",$"{account.Key} -> {account.Value}" +Environment.NewLine);
            }

        }
    }
}