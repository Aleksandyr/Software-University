using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using DatabaseAds;

namespace _02.PlayWithToList
{
    class Program
    {
        static void Main()
        {
            var db = new AdsEntities();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            SlowQuery(db);
            Console.WriteLine("Slow query: " + stopWatch.Elapsed);

            stopWatch.Restart();

            OptimizedQuery(db);
            Console.WriteLine("Optimized query: " + stopWatch.Elapsed);
        }

        private static void SlowQuery(AdsEntities db)
        {
            var ads = db.Ads
                .ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .SelectMany(a => new[]
                {
                    a.Title,
                    (a.CategoryId == null) ? "no category" : a.Category.Name,
                    (a.TownId == null) ? "no town" : a.Town.Name,
                }).ToList();
            //for (int i = 0; i < ads.Count; i += 3)
            //{
            //    Console.WriteLine("{0} {1} {2}", ads[i], ads[i + 1], ads[i + 2]);
            //}
        }

        private static void OptimizedQuery(AdsEntities db)
        {
            var ads = db.Ads
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Include(a => a.Category)
                .Include(a => a.Town)
                .ToList();
            
            //foreach (var ad in ads)
            //{
            //    Console.WriteLine("{0} {1} {2}",
            //        ad.Date,
            //        (ad.CategoryId == null) ? "no category" : ad.Category.Name,
            //        (ad.TownId == null) ? "no town" : ad.Town.Name);
            //}
        }
    }
}
