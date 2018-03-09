using System;
using System.Collections.Generic;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    public StudentSystem()
    {
        this.repo = new Dictionary<string, Student>();
    }

  

    public void ParseCommand(string command)
    {
        string[] args = command.Split();

        if (args[0] == "Create")
        {
            string name = args[1];
            int age = int.Parse(args[2]);
            double grade = double.Parse(args[3]);
            Create(name, age, grade);
        }
        else if (args[0] == "Show")
        {
            var name = args[1];
            Show(name);
        }
        
    }

    private void Show(string name)
    {
        if (repo.ContainsKey(name))
        {
            Console.WriteLine(repo[name]);
        }
    }

    private void Create(string name,int age,double grade)
    {
        
        if (!repo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            repo[name] = student;
        }
    }
}