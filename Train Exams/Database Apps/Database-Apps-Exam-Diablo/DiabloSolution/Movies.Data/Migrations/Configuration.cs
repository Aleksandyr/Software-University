using System.IO;
using Movies.Models;
using Newtonsoft.Json.Linq;

namespace Movies.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Movies.Data.MoviesEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Movies.Data.MoviesEntities";
        }

        protected override void Seed(Movies.Data.MoviesEntities context)
        {
            if (!context.Users.Any() && !context.Countries.Any() && !context.Movies.Any() &&
                !context.Ratings.Any())
            {
                var jsonFileCountries = File.ReadAllText("../../countries.json");
                JArray jsonArrayCountries = JArray.Parse(jsonFileCountries);
                foreach (var json in jsonArrayCountries)
                {
                    var county = new Country();
                    county.Name = json["name"].ToString();
                    context.Countries.Add(county);
                }

                context.SaveChanges();

                var jsonFileUsers = File.ReadAllText("../../users.json");
                JArray jsonArrayUsers = JArray.Parse(jsonFileUsers);
                foreach (var json in jsonArrayUsers)
                {
                    var user = new User();
                    user.Username = json["username"].ToString();
                    if (!string.IsNullOrEmpty(json["age"].ToString()))
                    {
                        user.Age = Convert.ToInt32(json["age"].ToString());
                    }
                    if (json["email"] != null)
                    {
                        user.Email = json["email"].ToString();
                    }
                    if (json["country"] != null)
                    {
                        var countryName = json["country"].ToString();
                        user.Country = context.Countries.FirstOrDefault(c => c.Name == countryName);
                    }
                    context.Users.Add(user);
                }

                context.SaveChanges();

                var jsonFileMovies = File.ReadAllText("../../movies.json");
                JArray jsonArrayMovies = JArray.Parse(jsonFileMovies);
                foreach (var json in jsonArrayMovies)
                {
                    var movie = new Movie();
                    movie.Isbn = json["isbn"].ToString();
                    if (!string.IsNullOrEmpty(json["title"].ToString()))
                    {
                        movie.Title = json["title"].ToString();
                    }
                    movie.AgeRestriction = (AgeRestriction)Convert.ToInt32(json["ageRestriction"].ToString());

                    context.Movies.Add(movie);
                }

                context.SaveChanges();

                var jsonFileFavouriteMovies = File.ReadAllText("../../users-and-favourite-movies.json");
                JArray jsonArrayFavouriteMovies = JArray.Parse(jsonFileFavouriteMovies);
                foreach (var json in jsonArrayFavouriteMovies)
                {
                    var userName = json["username"].ToString();
                    var favMovies = context.Users.FirstOrDefault(u => u.Username == userName);
                    foreach (var movie in json["favouriteMovies"])
                    {
                        favMovies.Movies.Add(new Movie()
                        {
                            Isbn = movie.ToString()
                        });
                    }

                }
                context.SaveChanges();

                var jsonFileRaiting = File.ReadAllText("../../movie-ratings.json");
                JArray jsonArrayRaiting = JArray.Parse(jsonFileRaiting);
                foreach (var json in jsonArrayRaiting)
                {
                    var rating = new Rating();
                    var userName = json["user"].ToString();
                    var movieIsbn = json["movie"].ToString();
                    rating.User = context.Users.FirstOrDefault(u => u.Username == userName);
                    rating.Movie = context.Movies.FirstOrDefault(u => u.Isbn == movieIsbn);
                    rating.Stars = int.Parse(json["rating"].ToString());

                    context.Ratings.Add(rating);
                }

                context.SaveChanges();
            }
        }
    }
}
