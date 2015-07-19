using System;
using System.Data.Entity;
using System.Data.Entity.Migrations.Design;
using System.Runtime.InteropServices;

namespace BookShopSystem.ConsoleClient
{
    using System.Linq;
    using BookShopSystem.Data;

    class ConsoleClient
    {
        static void Main()
        {
            
            var db = new BookShopContext();
            var bookCount = db.Books.Count();

            //problem 1
            //var booksAfter2000 = db.Books.Where(b => b.releaseDate >= new DateTime(2000, 1, 1)).Select(b => b.Title).ToList();
            //foreach (var book in booksAfter2000)
            //{
            //    Console.WriteLine(book);
            //}

            //problem 2
            //var allAuthorWithReleasBookAfter1990 =
            //    db.Authors.Where(a => a.Books.Any(b => b.releaseDate <= new DateTime(1990, 1, 1))).Select(a => new
            //    {
            //        a.FirstName,
            //        a.LastName
            //    }).ToList();
            //foreach (var author in allAuthorWithReleasBookAfter1990)
            //{
            //    Console.WriteLine(author);
            //}

            //problem 3
            //var authorsOrderedByBooks = db.Authors.OrderByDescending(a => a.Books.Count).Select(a => new
            //{
            //    FirstName = a.FirstName,
            //    LastName = a.LastName,
            //    BooksCount = a.Books.Count
            //});

            //foreach (var author in authorsOrderedByBooks)
            //{
            //    Console.WriteLine("{0} {1} : books count: {2}", author.FirstName, author.LastName, author.BooksCount);
            //}

            //problem 4
            //var allBooksFromGeorgePowell = db.Books.Where(
            //    b => b.Author.FirstName + " " + b.Author.LastName == "George Powell")
            //    .OrderByDescending(b => b.releaseDate)
            //    .ThenBy(b => b.Title)
            //    .Select(b => new
            //    {
            //        Title = b.Title,
            //        ReleaseData = b.releaseDate,
            //        Copies = b.copies
            //    }).ToList();

            //foreach (var book in allBooksFromGeorgePowell)
            //{
            //    Console.WriteLine("Book: {0}, {1}, {2} copies", book.Title, book.ReleaseData, book.Copies);
            //}

            
            
            //add books in realted books many to many
            //var books = db.Books.Take(3).ToList();
            //books[0].RelatedBooks.Add(books[1]);
            //books[1].RelatedBooks.Add(books[0]);
            //books[0].RelatedBooks.Add(books[2]);
            //books[2].RelatedBooks.Add(books[0]);

            //db.SaveChanges();

            var books = db.Books.Where(b => b.RelatedBooks.Any());

            foreach (var book in books)
            {
                Console.WriteLine("--" + book.Title);
                foreach (var relatedBooks in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBooks.Title);
                }
            }
        }
    }
}
