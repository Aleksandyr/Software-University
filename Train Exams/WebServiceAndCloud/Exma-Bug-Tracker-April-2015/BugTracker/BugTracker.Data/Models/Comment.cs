using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public User Author { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public virtual Bug Bug { get; set; }
    }
}
