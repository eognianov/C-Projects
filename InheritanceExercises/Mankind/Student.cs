using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


public class Student:Human
{
    private const string FacultyNumberPattern = @"^[A-Za-z\d]{5,10}$";
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (!Regex.IsMatch(value, FacultyNumberPattern))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber):base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine(base.ToString());
        builder.AppendLine($"Faculty number: {this.FacultyNumber}");
        return builder.ToString().TrimEnd();
    }
}
