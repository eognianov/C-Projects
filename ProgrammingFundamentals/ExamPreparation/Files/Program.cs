using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> allFiles = new List<string>();
            for (int i = 0; i < n; i++)
            {
                allFiles.Add(Console.ReadLine());
            }
            string filter = Console.ReadLine();
            var filterTokens = Regex.Split(filter, " in ");
            var filterExt ="." + filterTokens[0];
            var fileRoot = filterTokens[1]+"\\";
            Dictionary<string,long> fileSize = new Dictionary<string, long>();
            foreach (var f in allFiles)
            {
                var filePlusSize = f.Split(';');
                long size = long.Parse(filePlusSize[1]);
                var path = filePlusSize[0];
                if (path.StartsWith(fileRoot) && path.EndsWith(filterExt))
                {
                    var tokens = path.Split('\\');
                    var fileName = tokens.Last();
                    fileSize[fileName] = size;
                }
            }
            
            var sortedOutputFiles = fileSize.OrderBy(fs => fs.Value).ThenBy(fs => fs.Key);
            foreach (var fs in sortedOutputFiles)
            {
                Console.WriteLine($"{fs.Key} - {fs.Value} KB");
            }
            
            if (fileSize.Count == 0)
            {
                Console.WriteLine("No");
            }
        }

    }
}
