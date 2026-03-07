using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31LINQExercise
{
    internal class _06MovingStreamingPlatform
    {
        class Movie 
        { 
            public string Title; 
            public string Genre; 
            public double Rating; 
            public int Year; 
        }


        static void Main(string[] args)
        {
            var movies = new List<Movie>
        {
            new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
            new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
            new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
        };

            Console.WriteLine("---------------");
            Console.WriteLine("---------------");
            Console.WriteLine("Movies With rating above 8");
            var ratin = movies.Where(x => x.Rating > 8);
            foreach (var i in ratin)
            {
                Console.WriteLine(i.Title);
            }
            Console.WriteLine("---------------");
            Console.WriteLine("Average Movie Rating in Genre");
            var avgRating = movies.GroupBy(x => x.Genre).Select(y => new
            {
                genre = y.Key,
                average = y.Average(z => z.Rating)
            });
            foreach (var i in avgRating)
            {
                Console.WriteLine(i.genre + " - " + i.average);
            }

            var latestGenre = movies.GroupBy(x => x.Genre).Select(y => new
            {
                genre = y.Key,
                movie = y.OrderByDescending(z => z.Year).First()
            });
            Console.WriteLine("---------------");
            Console.WriteLine("Latest Movie in each genre");

            foreach (var i in latestGenre)
            {
                Console.WriteLine(i.genre + " - " + i.movie.Title);
            }

            Console.WriteLine("---------------");
            Console.WriteLine("Top 5 Highest rated Movies");
            var topMovies = movies.OrderByDescending(x => x.Rating);
            foreach (var i in topMovies)
            {
                Console.WriteLine(i.Title + " - " + i.Rating);
            }

        }
    }
}
