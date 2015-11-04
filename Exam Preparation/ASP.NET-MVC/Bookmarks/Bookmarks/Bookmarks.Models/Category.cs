﻿namespace Bookmarks.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Bookmark> bookmarks;

        public Category()
        {
            this.bookmarks = new HashSet<Bookmark>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Bookmark> Bookmarks 
        {
            get
            {
                return this.bookmarks;
            }
            set
            {
                this.bookmarks = value;
            }
        }
    }
}
