using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Rating
    {
        
        public int Id { get; set; }
        
        [Range(0, 10)]
        public int Stars { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual User User { get; set; }

    }
}
