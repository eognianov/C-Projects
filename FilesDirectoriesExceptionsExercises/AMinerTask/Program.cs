using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = File.ReadAllLines("Input.txt");
                
            Dictionary<string, long> resourseBalance = new Dictionary<string, long>();
            for (int i = 0; i < inputData.Length-1; i+=2)
            {
                string resource = inputData[i];
                long quantity = long.Parse(inputData[i+1]);
                if (resourseBalance.ContainsKey(resource))
                {
                    resourseBalance[resource] += quantity;
                }
                else
                {
                    resourseBalance.Add(resource, quantity);
                }
            }
            File.WriteAllText("Output.txt","");
            foreach (var resuorce in resourseBalance)
            {
                File.AppendAllText("Output.txt",$"{resuorce.Key} -> {resuorce.Value}"+Environment.NewLine);
            }
        }
    }
}
