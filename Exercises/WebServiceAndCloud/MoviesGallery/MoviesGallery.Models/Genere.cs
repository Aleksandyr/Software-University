using System.Collections.Generic;

namespace MoviesGallery.Models
{
    public class Genere
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
