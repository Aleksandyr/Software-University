using System.Web.Http;
using MoviesGallery.Data;

namespace MoviesGallery.WebService.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController(IMovieGalleryData data)
        {
            this.Data = data;
        }

        public BaseApiController()
            : this(new MovieGalleryData(new MoviesGalleryContext()))
        {
            
        }

        public IMovieGalleryData Data { get; set; }
    }
}