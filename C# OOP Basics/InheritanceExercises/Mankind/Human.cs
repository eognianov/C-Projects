
using System;
using System.Text;

public class Human
{
    private string firstName;

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (char.IsLower(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: fistName");
            }
            if (!(value.Length > 3))
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            firstName = value;
        }
    }

    private string lastName;

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (char.IsLower(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: lastName");
            }
            if (value.Length<=2)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"First Name: {this.FirstName}");
        builder.AppendLine($"Last Name: {this.LastName}");
        return builder.ToString().TrimEnd();
    }
}
