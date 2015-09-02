using System;
namespace News.WebService.Models.BindingModels
{
    public class NewsBindingModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}