using System;

namespace BashSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentsRepository.InitializeData();
            StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");
        }
    }
}
