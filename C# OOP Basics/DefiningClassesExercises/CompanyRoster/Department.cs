using System.Collections.Generic;
using System.Linq;

public class Department
{
    private List<Employee> employees;
    private string name;

    public Department(string name)
    {
        employees = new List<Employee>();
        this.name = name;
    }

    public string Name
    {
        get
        {
            return name;
            
        }
        set { this.name = value; }
    }
    public List<Employee> Employees     
    {
        get { return employees; }
    }

    public decimal AverageSalary => this.employees.Select(e => e.Salary).Average();


    public void AddEmployee(Employee employee)
    {
        this.employees.Add(employee);
    }
}