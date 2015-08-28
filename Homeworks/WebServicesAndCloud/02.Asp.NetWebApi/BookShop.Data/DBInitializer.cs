using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BookShop.Models;

namespace BookShop.Data
{
    public class DBInitializer : DropCreateDatabaseIfModelChanges<BookShopEntities>
    {
        protected override void Seed(BookShopEntities context)
        {
            using (var authorReader = new StreamReader(@"E:\Software-University\Homeworks\WebServicesAndCloud\02.Asp.NetWebApi\BookShop.Data\authors.txt"))
            {
                var authorLine = authorReader.ReadLine();
                authorLine = authorReader.ReadLine();
                while (authorLine != null)
                {
                    var authorData = authorLine.Split(' ');
                    var author = new Author()
                    {
                        FirstName = authorData[0],
                        LastName = authorData[1]
                    };

                    context.Authors.Add(author);
                    authorLine = authorReader.ReadLine();
                }
            }

            context.SaveChanges();

            using (var categoryReader = new StreamReader(@"E:\Software-University\Homeworks\WebServicesAndCloud\02.Asp.NetWebApi\BookShop.Data\categories.txt"))
            {
                var categoryLine = categoryReader.ReadLine();
                categoryLine = categoryReader.ReadLine();
                while (categoryLine != null)
                {
                    var category = new Category()
                    {
                        Name = categoryLine
                    };

                    context.Categories.Add(category);
                    categoryLine = categoryReader.ReadLine();
                }
            }

            context.SaveChanges();

            var authors = context.Authors.ToList();
            Random rnd = new Random();
            using (var bookReader = new StreamReader(@"E:\Software-University\Homeworks\WebServicesAndCloud\02.Asp.NetWebApi\BookShop.Data\books.txt"))
            {
                var bookLine = bookReader.ReadLine();
                bookLine = bookReader.ReadLine();
                while (bookLine != null)
                {
                    var bookData = bookLine.Split(' ');
                    var title = bookData[5];
                    var price = double.Parse(bookData[3]);
                    var copies = int.Parse(bookData[2]);
                    var ageRestriction = (AgeRestriction) int.Parse(bookData[4]);
                    var authorIndex = rnd.Next(0, authors.Count);
                    var author = authors[authorIndex];
                    var edition = (EditinType) int.Parse(bookData[0]);
                
                    var book = new Book()
                    {
                        Title = title,
                        Price = price,
                        Copies = copies,
                        AgeRestriction = ageRestriction,
                        Author = author,
                        Edition = edition
                    };

                    context.Books.Add(book);
                    bookLine = bookReader.ReadLine();
                }
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
