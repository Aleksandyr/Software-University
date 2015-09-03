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
using MoviesGallery.Data;
using MoviesGallery.Models;
using MoviesGallery.WebService.Models.BindingModels;

namespace MoviesGallery.WebService.Controllers
{
    public class GenresController : BaseApiController
    {

        // GET: api/Genres
        public IHttpActionResult GetAllGenres()
        {
            var movies = this.Data.Geners.All();

            return this.Ok(movies);
        }

        public IHttpActionResult AddGenre([FromBody] GenreBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genre = new Genre()
            {
                Name = model.Name
            };

            this.Data.Geners.Add(genre);
            this.Data.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = genre.Id }, genre);
        }

        public IHttpActionResult UpdateGenre(int id, [FromBody] GenreBindingModel model)
        {
            var genre = this.Data.Geners.GetById(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genre.Id)
            {
                return BadRequest();
            }

            genre.Name = model.Name;

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteGenre(int id)
        {
            var genre = this.Data.Geners.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }

            this.Data.Geners.Delete(genre);
            this.Data.SaveChanges();

            return Ok(genre);
        }

    }
}