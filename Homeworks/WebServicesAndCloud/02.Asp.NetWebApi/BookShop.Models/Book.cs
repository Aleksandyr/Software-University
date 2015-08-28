using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Models
{
    public class Book
    {
        private ICollection<Category> categories;

        public Book()
        {
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Copies { get; set; }
        public EditinType Edition { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
