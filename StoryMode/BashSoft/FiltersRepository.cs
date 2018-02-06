using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft
{
    public static class FiltersRepository
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter,
            int studentsToTake)
        {
            if (wantedFilter =="excellent")
            {
                FilterAndTake(wantedData,ExcellentFilter,studentsToTake);
            }
            else if(wantedFilter=="average")
            {
                FilterAndTake(wantedData, AverageFilter,studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData,PoorFilter,studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentsFilter);
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter,
            int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var userName_Points in wantedData)
            {
                if (counterForPrinted==studentsToTake)
                {
                    break;
                }

                double averageMark = Average(userName_Points.Value);
                if (givenFilter(averageMark))
                {
                    OutputWriter.PrintStudent(userName_Points);
                    counterForPrinted++;
                }
            }
        }

        private static bool ExcellentFilter(double mark)
        {
            return mark >= 5.0;
        }

        private static bool AverageFilter(double mark)
        {
            return mark < 5.0 && mark >= 3.5;
;       }

        private static bool PoorFilter(double mark)
        {
            return mark <= 3.5;
        }

        private static double Average(List<int> scoresOnTasks)
        {
            int totalScore = 0;
            foreach (var scoresOnTask in scoresOnTasks)
            {
                totalScore += scoresOnTask;
            }

            var percentageOfAll = totalScore / (scoresOnTasks.Count * 100);
            var mark = percentageOfAll * 4 + 2;
            return mark;
        }
    }
}
