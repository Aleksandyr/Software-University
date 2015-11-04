namespace Bookmarks.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Bookmark
    {
        private ICollection<Vote> votes;
        private ICollection<Comment> comments;

        public Bookmark()
        {
            this.votes = new HashSet<Vote>();
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Url { get; set; }

        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Vote> Votes { 
            get 
            {
                return this.votes;
            }
            set
            {
                this.votes = value;
            }
        }

        public virtual ICollection<Comment> Comments 
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }
    }
}
