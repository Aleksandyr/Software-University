using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Movie
    {
        private ICollection<User> users;
        private ICollection<Rating> ratings;

        public Movie()
        {
            this.Users = new HashSet<User>();
            this.Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        
        [Required]
        public string Isbn { get; set; }
        
        [MinLength(2)]
        [MaxLength(100)]
        public string Title { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

    }
}
