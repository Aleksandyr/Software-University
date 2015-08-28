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
using BookShop.Data;
using BookShop.Models;
using BookShopWebApp.Models.BindingModels;
using BookShopWebApp.Models.ViewModels;

namespace BookShopWebApp.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {
        private BookShopEntities db = new BookShopEntities();
        // GET: api/Authors/5
        public IHttpActionResult GetAuthorById(int id)
        {
            var author = db.Authors.Select(a => new
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                BookTitles = a.Books.Select(b => b.Title)
            })
            .FirstOrDefault(a => a.Id == id);
        
            if (author == null)
            {
                return NotFound();
            }

            var authorView = new AuthorViewModel.AuthorBookViewModel()
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                BookTitles = author.BookTitles
            };

            return this.Ok(authorView);
        }

        [Route("{id}/books")]
        public IHttpActionResult GetBooksForAuthorById(int id)
        {
            var author = db.Authors.FirstOrDefault(a => a.Id == id);
            
            if (author == null)
            {
                return this.NotFound();
            }

            var authorView = new AuthorViewModel.AuthorBookViewModel()
            {
                BookTitles = author.Books.Select(b => b.Title)
            };

            return this.Ok(authorView);
        }

        // POST: api/Authors
        public IHttpActionResult PostAuthor([FromBody] AuthorBindingMethod model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var author = new Author()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            
            db.Authors.Add(author);
            db.SaveChanges();

            var authorView = new AuthorViewModel.AuthorInfoViewModel()
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            return this.Ok(authorView);
        }
    }
}