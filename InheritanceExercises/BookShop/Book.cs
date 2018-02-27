using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Book
{
    private string title;

    public string Title
    {
        get { return title; }
        protected set
        {
            if (value.Length<3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    private string author;

    public string Author
    {
        get { return author; }
        protected set
        {
            if (!IsNameValid(value))
            {
                throw  new ArgumentException(@"Author not valid!");
            }
            author = value;
        }
    }

    

    private decimal price;

    public virtual decimal Price
    {
        get { return price; }
        protected set
        {
            if (price<0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }


    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    private bool IsNameValid(string value)
    {
        string[] authorNames = value.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        if (authorNames.Length>1)
        {
            char[] lastName = authorNames[1].ToCharArray();
            if (char.IsDigit(lastName.First()))
            {
                return false;
            }
        }

        return true;
    }

    public override string ToString()
    {
        return $"Type: {this.GetType().Name}" + Environment.NewLine + $"Title: {this.Title}" + Environment.NewLine +
               $"Author: {this.Author}" + Environment.NewLine + $"Price: {this.Price:F2}";
    }
}

