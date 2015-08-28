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

namespace BookShopWebApp.Controllers
{
    [RoutePrefix("api/categoris")]
    public class CategoriesController : ApiController
    {
        private BookShopEntities db = new BookShopEntities();

        // GET: api/Categories
        [EnableQuery]
        public IHttpActionResult GetCategories()
        {
            var categories = this.db.Categories.Select(c => new
            {
                Id = c.Id,
                Name = c.Name
            });

            if (!categories.Any())
            {
                return this.NotFound();
            }

            return this.Ok(categories);
        }

        // GET: api/Categories/5
        [ResponseType(typeof (Category))]
        public IHttpActionResult GetCategoryById(int id)
        {
            Category category = db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            var viewModel = new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(viewModel);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof (void))]
        public IHttpActionResult PutCategory([FromUri] int id, [FromBody] CategoryBindingModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = this.db.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return this.NotFound();
            }

            var duplicate = this.db.Categories.Any(c => c.Name == categoryModel.Name);
            if (duplicate == true)
            {
                var message = string.Format("Category with {0} name already exist!", categoryModel.Name);
                return this.BadRequest(message);
            }

            category.Name = categoryModel.Name;
            this.db.SaveChanges();

            var viewModel = new CategoryViewModel()
            {
                Name = categoryModel.Name
            };

            return this.Ok(viewModel);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof (Category))]
        public IHttpActionResult PostCategory([FromBody] CategoryBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var duplicate = this.db.Categories.Any(c => c.Name == model.Name);
            if (duplicate == true)
            {
                var message = string.Format("Category with {0} name already exist!", model.Name);
                return this.BadRequest(message);
            }

            var category = new Category()
            {
                Name = model.Name
            };

            db.Categories.Add(category);
            db.SaveChanges();

            var viewModel = new CategoryViewModel()
            {
                Name = model.Name
            };

            return this.Ok(viewModel);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof (Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }
    }
}