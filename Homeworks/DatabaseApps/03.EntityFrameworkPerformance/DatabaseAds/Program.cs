using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAds
{
    class Program
    {
        public static void Main()
        {
            var db = new AdsEntities();
            var adsCount = db.Ads.Count();
        }
    }
}
