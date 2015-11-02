using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class User
    {
        private ICollection<Movie> movies;
        private ICollection<Rating> ratings;

        public User()
        {
            this.Movies = new HashSet<Movie>();
            this.Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        [MinLength(5)]
        [Required]
        public string Username { get; set; }

        public string Email { get; set; }
        public int? Age { get; set; }

        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
