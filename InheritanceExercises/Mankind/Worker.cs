using System;
using System.Collections.Generic;
using System.Text;


public class Worker:Human
{
    private decimal weekSalary;

    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value<=10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public decimal SalaryPerHour => WeekSalary / (decimal)(WorkHours * 5);

    private double workHours;

    public double WorkHours
    {
        get { return workHours; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHours = value;
        }
    }


    public Worker(string firstName, string lastName, decimal salary, double hours):base(firstName, lastName)
    {
        this.WeekSalary = salary;
        this.WorkHours = hours;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine(base.ToString());
        builder.AppendLine($"Week Salary: {this.WeekSalary:F2}");
        builder.AppendLine($"Hours per day: {this.WorkHours:F2}");
        builder.AppendLine($"Salary per hour: {SalaryPerHour:F2}");
        return builder.ToString().TrimEnd();
    }
}

