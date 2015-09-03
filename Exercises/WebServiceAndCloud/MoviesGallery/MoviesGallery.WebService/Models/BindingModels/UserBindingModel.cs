using System;

namespace MoviesGallery.WebService.Models.BindingModels
{
    public class UserBindingModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public DateTime BirthData { get; set; }

        public string PerosnalPage { get; set; }
    }
}