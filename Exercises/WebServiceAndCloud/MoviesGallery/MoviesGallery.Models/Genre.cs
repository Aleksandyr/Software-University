using System.Collections.Generic;

namespace MoviesGallery.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
