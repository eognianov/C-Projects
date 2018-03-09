using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HornetComm
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> dict = new Dictionary<string, string>();
            dict.Add("hornet","comm");

            List<string> messeges = new List<string>();
            List<string> broadcasts = new List<string>();
            string messageRegex = @"^([\d]+) <-> ([0-9a-zA-Z]+)$";
            string broadcastRegex = @"^([\D]+) <-> ([0-9a-zA-Z]+)$";

            Regex message = new Regex(messageRegex);
            Regex broadcast = new Regex(broadcastRegex);
            string input;
            while ((input = Console.ReadLine()) != "Hornet is Green")
            {
                var intputArgs = input.Split(new string[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries);
                if (message.IsMatch(input))
                {
                    
                    messeges.Add($"{string.Join("",intputArgs[0].ToCharArray().Reverse())} -> {intputArgs[1]}");
                }
                if (broadcast.IsMatch(input))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var c in intputArgs[1].ToCharArray())
                    {
                        if (Char.IsLower(c))
                        {
                            sb.Append(Char.ToUpper(c));
                            continue;
                        }
                        if (Char.IsUpper(c))
                        {
                            sb.Append(Char.ToLower(c));
                            continue;
                        }
                        sb.Append(c);
                    }
                    broadcasts.Add($"{sb.ToString()} -> {intputArgs[0]}");
                }
            }
            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {   
                foreach (var currentbBroadcast in broadcasts)
                {
                    Console.WriteLine(currentbBroadcast);
                }
            }
            Console.WriteLine("Messages:");
            if (messeges.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var currentMessege in messeges)
                {
                    Console.WriteLine(currentMessege);
                }
            }
        }
    }
}
