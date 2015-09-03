using System.Linq;
using System.Web.Http;
using MoviesGallery.Models;
using MoviesGallery.WebService.Models.BindingModels;

namespace MoviesGallery.WebService.Controllers
{
    public class ReviewsController : BaseApiController
    {
        public IHttpActionResult AddReview(int movieId, [FromBody] ReviewBindingModel model)
        {
            var movie = this.Data.Moveis.GetById(movieId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (movie == null)
            {
                return this.BadRequest("Movie is not exist!");
            }

            var review = new Review()
            {
                CreatedOn = model.CreatedOn,
                Movie = movie
            };

            this.Data.Reviews.Add(review);
            this.Data.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = review.Id }, review);
        }

        public IHttpActionResult DeleteReview(int id)
        {
            var review = this.Data.Reviews.GetById(id);
            if (review == null)
            {
                return NotFound();
            }

            this.Data.Reviews.Delete(review);
            this.Data.SaveChanges();

            return Ok(review);
        }
    }
}
