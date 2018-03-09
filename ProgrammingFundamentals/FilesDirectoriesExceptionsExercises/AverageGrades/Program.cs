using System;
using System.Collections.Generic;
using System.IO;
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
            string[] inputDate = File.ReadAllLines("Input.txt");
            int n = int.Parse(inputDate[0]);
            List<Student> students = new List<Student>();
            for (int i = 1; i <= n; i++)
            {
                Student student = new Student();
                string[] inputArguments = inputDate[i].Split();
                student.Name = inputArguments[0];
                student.Grades = inputArguments.Skip(1).Select(double.Parse).ToList();
                students.Add(student);
            }
            File.WriteAllText("Output.txt","");
            students.Where(s => s.AverageGrade >= 5.00).OrderBy(s => s.Name).ThenByDescending(s => s.AverageGrade).ToList().ForEach(s => File.AppendAllText("Output.txt", $"{s.Name} -> {s.AverageGrade:F2}"+Environment.NewLine));
        }
    }
}
