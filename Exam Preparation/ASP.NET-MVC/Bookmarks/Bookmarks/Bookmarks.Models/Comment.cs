using System.ComponentModel.DataAnnotations;
namespace Bookmarks.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int BookmarkId { get; set; }

        public Bookmark Bookmark { get; set; }
    }
}
