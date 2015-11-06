using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippets.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreationTime { get; set; }

        [Required]
        public int SnippetId { get; set; }

        public virtual Snippet Snippet { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
