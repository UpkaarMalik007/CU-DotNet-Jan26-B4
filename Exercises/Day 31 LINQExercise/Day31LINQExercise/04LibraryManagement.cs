using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31LINQExercise
{
    class Book
    {
        public string Title;
        public string Author;
        public string Genre;
        public int Year;
        public double Price;
    }
    internal class _04LibraryManagement
    {
        
        static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
                new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
                new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
            };
            Console.WriteLine("---------------");
            Console.WriteLine("---------------");

            Console.WriteLine("Books Published After 2015");
            var bookspub = books.Where(x => x.Year > 2015);
            foreach (var i in bookspub)
            {
                Console.WriteLine(i.Title);
            }
            Console.WriteLine("---------------");
            Console.WriteLine("groupBy Genre and Count");

            var cnt = books.GroupBy(x => x.Genre).Select(y => new
            {
                genre = y.Key,
                Count = y.Count()
            });
            foreach (var i in cnt)
            {
                Console.WriteLine(i.genre + " - " + i.Count);
            }
            Console.WriteLine("---------------");
            Console.WriteLine("Most Expensive Book");
            var expensive = books.GroupBy(x => x.Genre).Select(y => new
            {
                genre = y.Key,
                exp = y.OrderByDescending(z => z.Price).First()
            });

            foreach (var i in expensive)
            {
                Console.WriteLine(i.genre + " - " + i.exp.Title);
            }
            Console.WriteLine("---------------");
            Console.WriteLine("Distinct Authors");
            var auth = books.Select(x => x.Author).Distinct();
            foreach (var i in auth)
            {
                Console.WriteLine(i);
            }
        }
    }
}
