using System.Collections.Generic;

namespace BookShop.Models
{
    public class Category
    {
        private ICollection<Book> books;

        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; } 
            set { this.books = value; }
        }
    }
}
