using System.Data.Entity;
using Mountains.Models;

namespace Mountains.Data
{
    public class MountainsMigrationsStrategy : DropCreateDatabaseAlways<MountainsEntities>
    {
        protected override void Seed(MountainsEntities context)
        {
            var bulgaria = context.Countries.Add(new Country()
            {
                CountryCode = "BG",
                ContryName = "Bulgaria"
            });
            var germany = context.Countries.Add(new Country()
            {
                CountryCode = "GM",
                ContryName = "Germany"
            });

            context.SaveChanges();

            var rila = context.Mountains.Add(new Mountain()
            {
                MountainName = "Rila",
                Countries = { bulgaria }
            });
            var pirin = context.Mountains.Add(new Mountain()
            {
                MountainName = "pirin",
                Countries = { bulgaria }
            });
            var rhodopes = context.Mountains.Add(new Mountain()
            {
                MountainName = "Rhodopes",
                Countries = { bulgaria }
            });

            context.SaveChanges();

            var musala = context.Peaks.Add(new Peak()
            {
                Name = "Musala",
                Elevation = 2925,
                Mountain = rila 
            });
            var malyovitsa = context.Peaks.Add(new Peak()
            {
                Name = "Malyovitsa",
                Elevation = 2729,
                Mountain = rila
            });
            var vihren = context.Peaks.Add(new Peak()
            {
                Name = "vihren",
                Elevation = 2914,
                Mountain = pirin
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
