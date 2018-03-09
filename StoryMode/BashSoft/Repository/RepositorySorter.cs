using System.Collections.Generic;
using System.Linq;
using BashSoft.IO;
using BashSoft.StaticData;

namespace BashSoft.Repository
{
    public class RepositorySorter
    {
        public void OrderAndTake(Dictionary<string, double> studentsMarks, string comparison, int studentsToTake)
        {
            
            comparison = comparison.ToLower();
            if (comparison=="ascending")
            {
                PrintStudents(studentsMarks.OrderBy(x=>x.Value).Take(studentsToTake).ToDictionary(pair=>pair.Key, pair=>pair.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudents(studentsMarks.OrderByDescending(x => x.Value).Take(studentsToTake).ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private void PrintStudents(Dictionary<string, double> studentSorted)
        {
            foreach (var student in studentSorted)
            {
               OutputWriter.PrintStudent(student);
            }
        }
    }
}
