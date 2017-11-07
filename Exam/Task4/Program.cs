using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,decimal> > dataSets = new Dictionary<string, Dictionary<string, decimal>>();
            Dictionary<string, Dictionary<string,decimal> > cache = new Dictionary<string, Dictionary<string, decimal>>();
            string inputLine = Console.ReadLine();
            while (inputLine != "thetinggoesskrra")
            {
                string[] inputArgs = inputLine.Split(new char[] {'-','>','|',' '}, StringSplitOptions.RemoveEmptyEntries);
                if (inputArgs.Length == 1)
                {
                    string dataSetName = inputArgs[0];

                    dataSets.Add(dataSetName, new Dictionary<string, decimal>());
                    if (cache.ContainsKey(dataSetName))
                    {
                        foreach (var pair in cache)
                        {
                            if (pair.Key == dataSetName)
                            {
                                foreach (var VARIABLE in cache[dataSetName])
                                {
                                    dataSets[dataSetName].Add(VARIABLE.Key,VARIABLE.Value);
                                }
                            }
                            
                        }
                    }
                }
                else
                {
                    string dataKey = inputArgs[0];
                    decimal dataValue = decimal.Parse(inputArgs[1]);
                    string dataSetName = inputArgs[2];
                    if (dataSets.ContainsKey(dataSetName))
                    {
                        dataSets[dataSetName].Add(dataKey, dataValue);
                    }
                    else
                    {
                        if (!cache.ContainsKey(dataSetName))
                        {
                            cache.Add(dataSetName, new Dictionary<string, decimal>());
                        }
                        cache[dataSetName].Add(dataKey,dataValue);
                    }
                }
                    
                inputLine= Console.ReadLine();
            }
            
                SortedDictionary<decimal, string> dataSetTotal = new SortedDictionary<decimal, string>();

                foreach (var dataSet in dataSets)
                {
                    decimal sum = dataSets[dataSet.Key].Values.Sum();
                    dataSetTotal[sum] = dataSet.Key;
                }

                var best = dataSetTotal.OrderByDescending(x => x.Key).FirstOrDefault();
                if (best.Key != 0)
                {
                    Console.WriteLine($"Data Set: {best.Value}, Total Size: {best.Key}");
                    foreach (var ds in dataSets[best.Value].Keys)
                    {
                        Console.WriteLine($"$.{ds}");
                    }
                }

        }

       
    }
}
