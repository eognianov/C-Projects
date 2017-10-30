using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CameraView
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cameraParams = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string inputData = Console.ReadLine();
            List<string> seenObjects = new List<string>();
            string pattern = @"\|<+\w+";
           

            foreach (Match m in Regex.Matches(inputData, pattern))
            {
                try
                {
                    seenObjects.Add(m.Value.Substring(2 + cameraParams[0],cameraParams[1]));
                }
                catch (Exception e)
                {
                    seenObjects.Add(m.Value.Substring(2 + cameraParams[0]));
                }
                
            }
            Console.WriteLine(string.Join(", ",seenObjects.ToArray()));
        }
    }
}
