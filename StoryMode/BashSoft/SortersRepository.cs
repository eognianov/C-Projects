using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BashSoft
{
    public static class SortersRepository
    {
        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison, int studentsToTake)
        {
            
            comparison = comparison.ToLower();
            if (comparison=="ascending")
            {
                PrintStudents(wantedData.OrderBy(x=>x.Value.Sum()).Take(studentsToTake).ToDictionary(pair=>pair.Key, pair=>pair.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudents(wantedData.OrderByDescending(x => x.Value.Sum()).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private static void PrintStudents(Dictionary<string, List<int>> studentSorted)
        {
            foreach (var student in studentSorted)
            {
                OutputWriter.PrintStudent(student);
            }
        }
    }
}
