using System;
using System.Diagnostics;
using System.Linq;
using DatabaseAds;

namespace _03.SelectEverythingFromAds
{
    class Program
    {
        static void Main()
        {
            var db = new AdsEntities();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var selectAllFromAds = db.Ads;
            foreach (var selectAllFromAd in selectAllFromAds.Take(3))
            {
                Console.WriteLine(selectAllFromAd.Title);
            }
            Console.WriteLine("Select all from ads: " + stopWatch.Elapsed);

            stopWatch.Restart();

            var selectTitleFromAds = db.Ads.Select(a => a.Title);
            foreach (var selectTitleFromAd in selectTitleFromAds.Take(3))
            {
                Console.WriteLine(selectTitleFromAd);
            }

            Console.WriteLine("Select title from ads: " + stopWatch.Elapsed);
        }
    }
}
