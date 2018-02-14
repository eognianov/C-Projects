using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        List<Department> departments = new List<Department>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] emInput = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string name = emInput[0];
            decimal salary = decimal.Parse(emInput[1]);
            string position = emInput[2];
            string departmentName = emInput[3];
            string email = "n/a";
            int age = -1;

            if (emInput.Length == 6)
            {
                email = emInput[4];
                age = int.Parse(emInput[5]);
            }
            else if (emInput.Length==5)
            {
                bool isAge = int.TryParse(emInput[4], out age);
                if (!isAge)
                {
                    email = emInput[4];
                    age = -1;
                }
                
            }
            if (!departments.Any(d=>d.Name == departmentName))
            {
                Department department = new Department(departmentName);
                departments.Add(department);
            }

            Employee employee = new Employee(name,position,salary,age, email);
            departments.First(d=>d.Name == departmentName).AddEmployee(employee);
        }

        var highestAvgDep = departments.OrderByDescending(d => d.AverageSalary).First();
        Console.WriteLine($"Highest Average Salary: {highestAvgDep.Name}");
        foreach (var employee in highestAvgDep.Employees.OrderByDescending(e=>e.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
        }
    }
    
}

