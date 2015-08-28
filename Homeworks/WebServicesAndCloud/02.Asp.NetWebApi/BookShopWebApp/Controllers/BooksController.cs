using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using BookShop.Data;
using BookShop.Models;
using BookShopWebApp.Models.BindingModels;
using BookShopWebApp.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace BookShopWebApp.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private BookShopEntities db = new BookShopEntities();

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            var book = db.Books
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    Author = b.Author.FirstName + " " + b.Author.LastName,
                    b.AgeRestriction,
                    b.Copies,
                    b.Edition,
                    b.Description,
                    b.Price,
                    Categories = b.Categories.Select(c => c.Name)
                })
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [EnableQuery]
        public IHttpActionResult GetBooksWithGivenSubString([FromUri] BookSearchBindingModel searchWord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = this.db.Books
                .Where(b => b.Title.Contains(searchWord.Search) ||
                            b.Description.Contains(searchWord.Search) ||
                            b.Edition.ToString().Contains(searchWord.Search)||
                            b.Categories.Select(c => c.Name).Any(c => c == searchWord.Search) ||
                            b.Author.FirstName.Contains(searchWord.Search) ||
                            b.Author.LastName.Contains(searchWord.Search))
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    Author = b.Author.FirstName + " " + b.Author.LastName,
                    b.AgeRestriction,
                    b.Copies,
                    b.Edition,
                    b.Description,
                    b.Price,
                    Categories = b.Categories.Select(c => c.Name)
                })
                .Take(10)
                .ToList();


            if (!book.Any())
            {
                return this.NotFound();
            }

            return this.Ok(book);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook([FromBody] BookPostBindingModel bookPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categories = bookPost.Categories.Split(' ').Select(c => c.Trim()).ToList();
            var categoryList = new List<Category>();
            foreach (var category in categories)
            {
                var categoryDb = this.db.Categories.FirstOrDefault(ca => ca.Name == category);
                if (categoryDb == null)
                {
                    categoryList.Add(new Category() {Name = category});
                }
                else
                {
                    categoryList.Add(categoryDb);
                }
            }

            var newBook = new Book()
            {
                Title = bookPost.Title,
                Description = bookPost.Description,
                Price = bookPost.Price,
                Copies = bookPost.Copies,
                Edition = bookPost.EditinType,
                AgeRestriction = bookPost.AgeRestriction,
                Categories = categoryList,
                AuthorId = 1
            };

            db.Books.Add(newBook);
            db.SaveChanges();

            return this.Ok(bookPost);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        //[Authorize]
        public IHttpActionResult PutBook([FromUri] int id, [FromBody] BookPutBindingModel bookModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var book = this.db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }

            book.Title = bookModel.Title;
            book.Description = bookModel.Description;
            book.Price = bookModel.Price;
            book.Copies = bookModel.Copies;
            book.Edition = bookModel.EditinType;
            book.AgeRestriction = bookModel.AgeRestriction;
            book.AuthorId = bookModel.AuthorId;

            this.db.SaveChanges();

            return this.Ok(bookModel);
        }

        [Authorize]
        [Route("Buy/{id}")]
        public IHttpActionResult putBuyBook(int id)
        {
            var book = db.Books.Find(id);
            if (book == null)
            {
                return this.NotFound();
            }

            if (book.Copies < 0)
            {
                return this.BadRequest("No copies left!");
            }

            book.Copies--;

            var purchase = new Purchase()
            {
                Book = book,
                ApplicationUser = db.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name),
                Price = book.Price,
                DateOfPurchase = DateTime.Now,
                IsRecalled = false
            };

            db.Purchases.Add(purchase);
            db.SaveChanges();

            var purchaseView = new PurchaseViewModel()
            {
                BookName = book.Title,
                Price = book.Price,
                User = purchase.ApplicationUser.UserName
            };

            return this.Ok(purchaseView);
        }

        [Authorize]
        [Route("Recal/{id}")]
        public IHttpActionResult PutRecallBook(int id)
        {
            var purchase = db.Purchases.FirstOrDefault(p => p.Id == id);
            if (purchase == null)
            {
                return this.NotFound();
            }

            if (purchase.ApplicationUser.UserName != this.User.Identity.Name)
            {
                return this.BadRequest("You cannot return this purchase, you are not buyer!");
            }

            purchase.IsRecalled = true;
            purchase.Book.Copies++;
            db.SaveChanges();

            return this.Ok("Refunded!");
        }
    }
}