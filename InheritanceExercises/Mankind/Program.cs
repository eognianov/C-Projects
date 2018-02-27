using System;


public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] studentInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string studentFirstName = studentInput[0];
            string studentLastName = studentInput[1];
            string studentFacultyNumber = studentInput[2];

            Student student = new Student(studentFirstName, studentLastName, studentFacultyNumber);

            string[] workerInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string workerFirstName = workerInput[0];
            string workerLastName = workerInput[1];
            decimal weekSalary = decimal.Parse(workerInput[2]);
            double workHours = double.Parse(workerInput[3]);

            Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, workHours);

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch (ArgumentException ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
}

