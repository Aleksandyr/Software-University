using System;

namespace News.Models
{
    public class News
    {
        public int  Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedData { get; set; }
    }
}
