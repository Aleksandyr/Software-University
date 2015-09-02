using System;
using WebServices.Models;

namespace MoviesGallery.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
