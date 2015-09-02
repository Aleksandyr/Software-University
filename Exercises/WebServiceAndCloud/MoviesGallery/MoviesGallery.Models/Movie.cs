using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebServices.Models;

namespace MoviesGallery.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Range(0, 60)]
        public int Length { get; set; }

        [Range(1, 10)]
        public int Rotation { get; set; }

        public string Country { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
