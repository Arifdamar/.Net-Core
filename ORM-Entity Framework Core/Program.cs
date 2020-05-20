using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ORM_Entity_Framework_Core
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory
        = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLoggerFactory(MyLoggerFactory)
            //.UseSqlite("Data Source=shop.db");
            .UseSqlServer(@"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDb; Integrated Security=SSPI;");
        }
    }

    public class User
    {
        public User()
        {
            this.Addresses = new List<Address>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public List<Address> Addresses { get; set; } // navigation property
    }

    public class Address
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public User User { get; set; } // navigation property
        public int UserId { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // InsertUsers();
            // InsertAddresses();

            using (var db = new ShopContext())
            {
                var user = db.Users.FirstOrDefault(i => i.Username == "arifDamar");

                if (user != null)
                {
                    user.Addresses.AddRange(
                        new List<Address>()
                        {
                            new Address() { FullName = "Arif Damar", Title = "Home Address", Body = "Can/Canakkale/Turkey" },
                            new Address() { FullName = "Arif Damar", Title = "Job Address", Body = "Istanbul/Turkey" },
                            new Address() { FullName = "Arif Damar", Title = "School Address", Body = "Serdivan/Sakarya/Turkey" }
                        }
                    );
                    db.SaveChanges();
                }
            }
        }

        static void InsertUsers()
        {
            var users = new List<User>()
            {
                new User(){Username = "arifDamar", Email = "arif660damar@gmail.com"},
                new User(){Username = "arifDamar1", Email = "arif660damar1@gmail.com"},
                new User(){Username = "arifDamar2", Email = "arif660damar2@gmail.com"},
                new User(){Username = "arifDamar3", Email = "arif660damar3@gmail.com"}
            };

            using (var db = new ShopContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }
        static void InsertAddresses()
        {
            var addresses = new List<Address>()
            {
                new Address(){FullName = "Arif Damar", Title = "Home Address", Body = "Can/Canakkale/Turkey", UserId = 1},
                new Address(){FullName = "Arif Damar", Title = "Job Address", Body = "Can/Canakkale/Turkey", UserId = 1},
                new Address(){FullName = "Arif Damar1", Title = "Home Address", Body = "Can/Canakkale/Turkey", UserId = 2},
                new Address(){FullName = "Arif Damar2", Title = "Home Address", Body = "Can/Canakkale/Turkey", UserId = 3}
            };

            using (var db = new ShopContext())
            {
                db.Addresses.AddRange(addresses);
                db.SaveChanges();
            }
        }
    }
}
