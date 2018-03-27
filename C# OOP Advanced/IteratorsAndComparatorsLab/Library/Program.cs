﻿using System;


class Program
{
    static void Main(string[] args)
    {
        Book bookOne = new Book("Animal Farm", 0, "George Orwell");
        Book bookTwo = new Book("The Documents in the Case", 50, "Dorothy Sayers", "Robert Eustace");
        Book bookThree = new Book("The Documents in the Case", 14);

        Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

        foreach (var book in libraryTwo)
        {
            Console.WriteLine(book);
        }

    }
}

