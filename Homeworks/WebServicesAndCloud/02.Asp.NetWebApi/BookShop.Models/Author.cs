using System.Collections.Generic;

namespace BookShop.Models
{
    public class Author
    {
        private ICollection<Book> books;

        public Author()
        {
            this.Books = new HashSet<Book>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Book> Books
        {
            get { return this.books; } 
            set { this.books = value; }
        }
    }
}
