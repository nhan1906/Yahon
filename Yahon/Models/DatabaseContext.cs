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
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
        //Login sessions
        public DbSet<CustomerSession> CustomerSessions { get; set; }
        
    }

    /*public class DatabaseContextInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>()
    {
        protected override void Seed(DatabaseContext db)
        {
            IList<Customer> defaultCustomers = new List<Customer>();
            
            defaultCustomers.Add(new Customer()
            {
                CustomerId = 0,
                Email = "userEmail1@domain.com",
                CreationDate = DateTime.Now,
                Password = "asdasd",
                FirstName = "FirstName1",
                LastName = "LastName1",
                DateOfBirth = DateTime.Now,
                Address = "street1",
                Phone = "12345678",
            });
            defaultCustomers.Add(new Customer()
            {
                CustomerId = 1,
                Email = "userEmail1@domain.com",
                CreationDate = DateTime.Now,
                Password = "asdasd",
                FirstName = "FirstName1",
                LastName = "LastName1",
                DateOfBirth = DateTime.Now,
                Address = "street1",
                Phone = "12345678"
            });
            defaultCustomers.Add(new Customer()
            {
                CustomerId = 2,
                Email = "userEmail2@domain.com",
                CreationDate = DateTime.Now,
                Password = "asdasd",
                FirstName = "FirstName2",
                LastName = "LastName2",
                DateOfBirth = DateTime.Now,
                Address = "street2",
                Phone = "12345678"
            });
            defaultCustomers.Add(new Customer()
            {
                CustomerId = 3,
                Email = "userEmail3@domain.com",
                CreationDate = DateTime.Now,
                Password = "asdasd",
                FirstName = "FirstName3",
                LastName = "LastName3",
                DateOfBirth = DateTime.Now,
                Address = "street3",
                Phone = "12345678"
            });

            int i = 0;
            List<Customer> list = db.Customers.ToList();
            foreach (var customer in list)
            {
                customer.Purchases.Add(new Purchase
                {
                    PurchaseID = i,
                    CustomerID = i,
                    PurchaseDate = DateTime.Now,
                    PurchasePrice = 100000,
                    
                });
            }
        }
    }*/
}