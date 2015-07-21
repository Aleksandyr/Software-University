using System;
using System.Data.Entity;
using System.Linq;
using DatabaseAds;

namespace _01.RelatedTables
{
    class Program
    {
        static void Main()
        {
            var db = new AdsEntities();

            AdsWithoutInclude(db);
        }

        private static void AdsWithoutInclude(AdsEntities db)
        {
            foreach (var ad in db.Ads)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}",
                    ad.Title,
                    ad.AdStatus.Status,
                    (ad.CategoryId == null) ? "no data" : ad.Category.Name,
                    (ad.TownId == null) ? "no town" : ad.Town.Name,
                    ad.AspNetUser.Name);
            }
        }

        private static void AdsWithInclude(AdsEntities db)
        {
            var ads = db.Ads
                .Include(a => a.AdStatus)
                .Include(a => a.Category)
                .Include(a => a.Town)
                .Include(a => a.AspNetUser);

            foreach (var ad in db.Ads)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}",
                    ad.Title,
                    ad.AdStatus.Status,
                    (ad.CategoryId == null) ? "no data" : ad.Category.Name,
                    (ad.TownId == null) ? "no town" : ad.Town.Name,
                    ad.AspNetUser.Name);
            }
        }
    }
}
