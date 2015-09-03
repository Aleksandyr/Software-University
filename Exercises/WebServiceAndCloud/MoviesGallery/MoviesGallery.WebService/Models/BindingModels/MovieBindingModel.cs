using MoviesGallery.Models;

namespace MoviesGallery.WebService.Models.BindingModels
{
    public class MovieBindingModel
    {
        public string Title { get; set; }

        public int Length { get; set; }

        public int Rotation { get; set; }
    }
}