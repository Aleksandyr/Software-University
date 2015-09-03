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
    public class MoviesController : BaseApiController
    {
        // GET: api/Movies
        public IHttpActionResult GetAllMovies()
        {
            var movies = this.Data.Moveis.All();

            return this.Ok(movies);
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovieById(int id)
        {
            Movie movie = this.Data.Moveis.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return this.Ok(movie);
        }

        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMoviesByGenre([FromUri] int id)
        {
            var movie = this.Data.Moveis.All().Where(m => m.Genre.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return this.Ok(movie);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult UpdateMovie(int id, [FromBody] MovieBindingModel model)
        {
            var movie = this.Data.Moveis.GetById(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.Id)
            {
                return BadRequest();
            }

            movie.Title = model.Title;
            movie.Length = movie.Length;
            movie.Rotation = movie.Rotation;
           
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public IHttpActionResult AddMovie([FromBody] MovieBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var moive = new Movie()
            {
                Title = model.Title,
                Length = model.Length,
                Rotation = model.Rotation
            };

            this.Data.Moveis.Add(moive);
            this.Data.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = moive.Id }, moive);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = this.Data.Moveis.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }

            this.Data.Moveis.Delete(movie);
            this.Data.SaveChanges();

            return Ok(movie);
        }
    }
}