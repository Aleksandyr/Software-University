namespace BookShopSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        private ICollection<Category> categories;

        public Book()
        {
            this.categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }

        [MinLength(1)]
        [MaxLength(1000)]
        public string Description { get; set; }

        public EditionType EditionType { get; set; }

        public decimal Price { get; set; }
        public int copies { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public DateTime? releaseDate { get; set; }

        public int AuthorID { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set {this.categories = value; }
        }
    }
}
