using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;


namespace BookLibrary
{
    class Program
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

        public static void Main()
        {
            List<Book> books = GetBooks();
            Dictionary<string, decimal> salesByAuthor = new Dictionary<string, decimal>();

            foreach (string author in books.Select(x => x.Author).Distinct())
                salesByAuthor.Add(author, books.Where(x => x.Author == author)
                    .Select(x => x.Price)
                    .Sum());
            File.WriteAllText("Output.txt", "");
            
            foreach (var pair in salesByAuthor
                .OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                File.AppendAllText("Output.txt", $"{pair.Key} -> {pair.Value}" + Environment.NewLine);
        }

        private static List<Book> GetBooks()
        {
            string[] inputData = File.ReadAllLines("Input.txt");
            List<Book> books = new List<Book>();
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
