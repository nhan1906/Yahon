using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Yahon.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(): base("WebDB")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
        //Login sessions
        public DbSet<CustomerSession> CustomerSessions { get; set; }
        public DbSet<Post> Posts { get; set; }
        
    }

    public class DatabaseContextInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext db)
        {
            IList<Brand> defaultBrands = new List<Brand>();

            defaultBrands.Add(new Brand()
            {
                BrandId = 0,
                BrandName = "BabyHood",
                BrandImage = "babyhood.PNG",
            });
            defaultBrands.Add(new Brand()
            {
                BrandId = 1,
                BrandName = "Best",
                BrandImage = "best.png",
            });
            defaultBrands.Add(new Brand()
            {
                BrandId = 2,
                BrandName = "Fair Lady",
                BrandImage = "brand-fairlady1528254859.jpg",
            });
            defaultBrands.Add(new Brand()
            {
                BrandId = 3,
                BrandName = "Keepers",
                BrandImage = "brand_box_copy.jpg",
            });
            defaultBrands.Add(new Brand()
            {
                BrandId = 4,
                BrandName = "Let Green",
                BrandImage = "let-green.png",
            });
            defaultBrands.Add(new Brand()
            {
                BrandId = 5,
                BrandName = "MotherHood",
                BrandImage = "motherhood.png",
            });
            defaultBrands.Add(new Brand()
            {
                BrandId = 6,
                BrandName = "Nuna",
                BrandImage = "nuna.png",
            });
            defaultBrands.Add(new Brand()
            {
                BrandId = 7,
                BrandName = "Pop One",
                BrandImage = "pop-one.png",
            });
            defaultBrands.Add(new Brand()
            {
                BrandId = 8,
                BrandName = "Pop Puf",
                BrandImage = "pop-puf.png",
            });
            defaultBrands.Add(new Brand()
            {
                BrandId = 9,
                BrandName = "Puffme",
                BrandImage = "puffme12871.png",
            });
            defaultBrands.Add(new Brand()
            {
                BrandId = 10,
                BrandName = "Travel Mate",
                BrandImage = "travel-mate.png",
            });
            defaultBrands.Add(new Brand()
            {
                BrandId = 11,
                BrandName = "Wet One",
                BrandImage = "wet-one.png",
            });
            defaultBrands.Add(new Brand()
            {
                BrandId = 12,
                BrandName = "Wuna",
                BrandImage = "wuna.png",
            });

            foreach(var item in defaultBrands)
            {

                db.Brands.Add(item);
            }
        }
    }
}