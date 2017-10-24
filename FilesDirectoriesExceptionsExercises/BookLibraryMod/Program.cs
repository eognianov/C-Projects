using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryMod
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
    }

    public class Book_Library_Modification
    {
        public static void Main()
        {
            List<Book> books = GetBooks();
            DateTime targetReleaseDate = DateTime.ParseExact(File.ReadAllLines("Input.txt").Last().ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            string[] titlesReleasedAfterDate = books
                                            .Where(x => x.ReleaseDate > targetReleaseDate)
                                            .OrderBy(x => x.ReleaseDate).ThenBy(x => x.Title)
                                            .Select(x => x.Title).Distinct()
                                            .ToArray();
            File.WriteAllText("Output.txt", "");
            foreach (string title in titlesReleasedAfterDate)
            {
                DateTime[] bookReleaseDates = books
                                            .Where(x => x.Title == title && x.ReleaseDate > targetReleaseDate)
                                            .OrderBy(x => x.ReleaseDate)
                                            .Select(x => x.ReleaseDate).Distinct()
                                            .ToArray();
                
                foreach (DateTime bookReleaseDate in bookReleaseDates)
                    File.AppendAllText("Output.txt", $"{title} -> {bookReleaseDate:dd.MM.yyyy}" + Environment.NewLine);
                    
            }
        }

        private static List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            string[] inputData = File.ReadAllLines("Input.txt");
            int n = int.Parse(inputData[0]);
            for (int i = 1; i <= n; i++)
            {
                string[] data = inputData[i]
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                books.Add(new Book()
                {
                    Title = data[0],
                    Author = data[1],
                    Publisher = data[2],
                    ReleaseDate = DateTime.ParseExact(data[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    ISBN = data[4],
                    Price = decimal.Parse(data[5])
                });
            }
            return books;
        }
    }
}
