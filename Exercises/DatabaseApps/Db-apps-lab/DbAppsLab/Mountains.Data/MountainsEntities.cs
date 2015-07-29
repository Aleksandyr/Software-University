using Mountains.Models;

namespace Mountains.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MountainsEntities : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Mountains.Data.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public MountainsEntities()
            : base("name=MountainsEntities")
        {
        }

      
        public virtual DbSet<Mountain> Mountains { get; set; }
        public virtual DbSet<Peak> Peaks { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}