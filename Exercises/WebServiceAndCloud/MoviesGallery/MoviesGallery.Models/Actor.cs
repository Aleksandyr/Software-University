using System;
using System.Collections.Generic;
using WebServices.Models;

namespace MoviesGallery.Models
{
    public class Actor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BornDate { get; set; }

        public string Biography { get; set; }

        public string HomeTown { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
