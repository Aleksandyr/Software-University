using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using MoviesGallery.Models;
using MoviesGallery.WebService.Models.BindingModels;

namespace MoviesGallery.WebService.Controllers
{
    public class ActorsController : BaseApiController
    {
        public IHttpActionResult AddActor(int movieId, [FromBody] ActorBindingModel model)
        {
            var movie = this.Data.Moveis.GetById(movieId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (movie == null)
            {
                return this.BadRequest("Movie is not exist");
            }

            var actor = new Actor()
            {
                BornDate = model.BornDate,
                Movies = (ICollection<Movie>)movie
            };

            this.Data.Actors.Add(actor);
            this.Data.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = actor.Id }, actor);
        }

        public IHttpActionResult UpdateActor(int id, [FromBody] ActorBindingModel model)
        {
            var actor = this.Data.Actors.GetById(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actor.Id)
            {
                return BadRequest();
            }

            actor.BornDate = model.BornDate;

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteActor(int id)
        {
            var actor = this.Data.Actors.GetById(id);
            if (actor == null)
            {
                return NotFound();
            }

            this.Data.Actors.Delete(actor);
            this.Data.SaveChanges();

            return Ok(actor);
        }
    }
}
