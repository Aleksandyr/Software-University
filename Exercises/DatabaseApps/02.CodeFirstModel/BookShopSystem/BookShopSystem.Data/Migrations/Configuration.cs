using System.Globalization;
using System.IO;
using System.Xml;
using BookShopSystem.Model;

namespace BookShopSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopSystem.Data.BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "BookShopSystem.Data.BookShopContext";
        }

        protected override void Seed(BookShopSystem.Data.BookShopContext context)
        {
            var random = new Random();

            using (var authorReader = new StreamReader(@"E:\Software-University\Exercises\DatabaseApps\02.CodeFirstModel\authors.txt"))
            {
                var authorLine = authorReader.ReadLine();
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

            var authors = context.Authors.ToList();
            using (var reader = new StreamReader(@"E:\Software-University\Exercises\DatabaseApps\02.CodeFirstModel\books.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] {' '}, 6);
                    var authorIndex = random.Next(0, authors.Count);
                    var author = authors[authorIndex];
                    var edition = (EditionType) int.Parse(data[0]);
                    var realeaseData = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(data[2]);
                    var price = decimal.Parse(data[3]);
                    var ageRestriction = (AgeRestriction) int.Parse(data[4]);
                    var title = data[5];

                    context.Books.Add(new Book()
                    {
                        Author = author,
                        EditionType = edition,
                        releaseDate = realeaseData,
                        copies = copies,
                        Price = price,
                        AgeRestriction = ageRestriction,
                        Title = title
                    });

                    line = reader.ReadLine();
                }
            }

            context.SaveChanges();

            var books = context.Books.ToList();

            using (var categoriesReader = new StreamReader(@"E:\Software-University\Exercises\DatabaseApps\02.CodeFirstModel\categories.txt"))
            {
                var categoryName = categoriesReader.ReadLine();
                while (categoryName != null)
                {
                    var bookIndex = random.Next(0, books.Count);
                    var category = new Category()
                    {
                        Name = categoryName,
                    };

                    context.Categories.Add(category);

                    categoryName = categoriesReader.ReadLine();
                }
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
