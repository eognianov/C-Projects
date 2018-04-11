using System;
using System.Collections.Generic;
using System.Linq;
using BashSoft.Contracts;
using BashSoft.IO;
using BashSoft.StaticData;

namespace BashSoft.Repository
{
    public class RepositoryFilter:IDataFilter
    {
        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter =="excellent")
            {
                FilterAndTake(studentsWithMarks, x=> x >= 5,studentsToTake);
            }
            else if(wantedFilter=="average")
            {
                FilterAndTake(studentsWithMarks, x=> x<5&& x>=3.5,studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(studentsWithMarks, x=>x<3.5,studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentsFilter);
            }
        }

        private void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;

            foreach (var studentMark in studentsWithMarks)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                
                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(new KeyValuePair<string, double>(studentMark.Key, studentMark.Value));
                    counterForPrinted++;
                }
            }
        }

        private double Average(List<int> scoresOnTasks)
        {
            int totalScore = 0;
            foreach (var scoresOnTask in scoresOnTasks)
            {
                totalScore += scoresOnTask;
            }

            var percentageOfAll = totalScore / scoresOnTasks.Count * 100;
            var mark = percentageOfAll * 4 + 2;
            return mark;
        }
    }
}
