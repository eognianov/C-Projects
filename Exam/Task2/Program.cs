using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string commandLine = Console.ReadLine();
            while (commandLine!="3:1")
            {
                string[] commandArgs = commandLine.ToLower().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                switch (commandArgs[0])
                {
                    case "merge":
                        
                        int startIndex = int.Parse(commandArgs[1]);
                        int endIndex = int.Parse(commandArgs[2]);
                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }
                        if (endIndex >= inputData.Count)
                        {
                            endIndex = inputData.Count - 1;
                        }
                        List<string> result =new List<string>();
                        StringBuilder temp = new StringBuilder();
                        if (IsValidRange(inputData, startIndex, endIndex))
                        {
                            for (int i = 0; i < startIndex; i++)
                            {
                                result.Add(inputData[i]);
                            }
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                temp.Append(inputData[i]);
                            }
                            result.Add(temp.ToString());
                            for (int i = endIndex; i < inputData.Count; i++)
                            {
                                if (i == endIndex)
                                {
                                    continue;
                                }
                                result.Add(inputData[i]);
                            }
                            inputData = result;
                        }
                        break;
                    case "divide":
                        int index = int.Parse(commandArgs[1]);
                        int numberOfPartisions = int.Parse(commandArgs[2]);
                        if (numberOfPartisions == 0)
                        {
                            break;
                            
                        }
                        StringBuilder partisions = new StringBuilder(); 
                        char[] stringToDivide = inputData[index].ToCharArray();
                        int partisionSize = stringToDivide.Length / numberOfPartisions;
                        int lastPartitionSize = stringToDivide.Length - ((numberOfPartisions-1)  * partisionSize);
                        inputData.RemoveAt(index);
                            int count = 0;
                        if (lastPartitionSize != 0)
                        {
                            for (int i = 0; i < stringToDivide.Length-lastPartitionSize; i++)
                            {
                                if (count == partisionSize)
                                {
                                    partisions.Append(" ");
                                    count = 0;
                                }
                                partisions.Append(stringToDivide[i]);
                                count++;
                            }
                            partisions.Append(" ");
                            for (int i = stringToDivide.Length - lastPartitionSize; i < stringToDivide.Length; i++)
                            {
                                partisions.Append(stringToDivide[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < stringToDivide.Length - lastPartitionSize; i++)
                            {
                                if (count == partisionSize)
                                {
                                    partisions.Append(" ");
                                    count = 0;
                                }
                                partisions.Append(stringToDivide[i]);
                                count++;
                            }
                        }

                        inputData.Insert(index,partisions.ToString());
                       
                        break;
                }   
                        
                
                
                commandLine = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",inputData));
        }

       
        private static bool IsValidRange(List<string> items, int startIndex, int endIdex)
        {
            if (startIndex < 0)
                return false;
            if (startIndex >= items.Count)
                return false;
           
            if (endIdex >= items.Count)
                return false;
            return true;
        }


      

        
    }

}
