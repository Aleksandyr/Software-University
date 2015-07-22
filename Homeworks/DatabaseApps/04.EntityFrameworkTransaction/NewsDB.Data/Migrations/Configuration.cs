using NewsDB.Model;

namespace NewsDB.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsDB.Data.NewsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "NewsDB.Data.NewsDBContext";
        }

        protected override void Seed(NewsDB.Data.NewsDBContext context)
        {
            if (context.News.Count() == 0)
            {
                context.News.Add(new New()
                {
                    ContentNews = "7 WordPress Plugins That Will Quickly Help Your Site Get More Traffic"
                });
                context.News.Add(new New()
                {
                    ContentNews = "4 Easy-to-Use Tips to Get People to Click on Your Headlines"
                });
                context.News.Add(new New()
                {
                    ContentNews = "The Psychology Behind Why We Like, Share and Comment on Facebook (Infographic)"
                });

                context.SaveChanges();
            }
        }
    }
}
