using ProductsShop.Model;

namespace ProductsShop.Data
{
    using ProductsShop.Data.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductsShopEntities : DbContext
    {
        public ProductsShopEntities()
            : base("name=ProductsShopEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductsShopEntities, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Friends).WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UserFriends");
                });

            modelBuilder.Entity<User>().HasMany(u => u.ProductsBought)
                .WithOptional(p => p.Buyer)
                .Map(m =>
                {
                    m.MapKey("BuyerId");
                });

            modelBuilder.Entity<User>().HasMany(u => u.ProductsSold)
                .WithRequired(p => p.Seller)
                .Map(m =>
                {
                    m.MapKey("SollerId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}