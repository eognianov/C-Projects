using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageGrades
{
    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double AverageGrade
        {
            get { return Grades.Average(); }
        }
    }

    public class Average_Grades
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                Student student = new Student();
                string[] inputArguments = Console.ReadLine().Split();
                student.Name = inputArguments[0];
                student.Grades = inputArguments.Skip(1).Select(double.Parse).ToList();
                students.Add(student);
            }
            students.Where(s => s.AverageGrade >= 5.00).OrderBy(s => s.Name).ThenByDescending(s => s.AverageGrade).ToList().ForEach(s => Console.WriteLine($"{s.Name} -> {s.AverageGrade:F2}"));
        }
    }
}