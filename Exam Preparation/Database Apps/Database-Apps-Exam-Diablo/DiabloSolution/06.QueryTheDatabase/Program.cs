using System;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using Movies.Data;
using Movies.Models;

namespace _06.QueryTheDatabase
{
    class Program
    {
        static void Main()
        {
            var db = new MoviesEntities();
            var movies = db.Movies.Where(m => m.AgeRestriction == AgeRestriction.Teen).Select(m => new
            {
                m.Isbn,
                m.Title,
                favouriteBy = m.Users.Select(u => u.Username)
            })
            .Take(10);
            foreach (var movie in movies)
            {
                Console.WriteLine(movie.Isbn + " " + movie.Title + " " + string.Join(", ", movie.favouriteBy));
            }
        }
    }
}
