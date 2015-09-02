using System;
using System.Linq.Expressions;
using News.Models;

namespace News.WebService.Models
{
    public class NewsViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishData { get; set; }

        public static Expression<Func<News.Models.News, NewsViewModel>> Create
        {
            get
            {
                return n => new NewsViewModel()
                {
                    Title = n.Title,
                    Content = n.Content,
                    PublishData = n.PublishedData
                };
            }
        } 
    }
}