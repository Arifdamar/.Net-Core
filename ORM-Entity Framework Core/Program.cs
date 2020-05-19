using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ORM_Entity_Framework_Core
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory
        = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLoggerFactory(MyLoggerFactory)
            .UseSqlite("Data Source=shop.db");
        }
    }

    public class Product
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
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
            AddProduct();
        }

        static void AddProducts()
        {
            using (var db = new ShopContext())
            {
                var products = new List<Product>
                {
                    new Product { Name = "Samsung Galaxy S8", Price = 4000 },
                    new Product { Name = "Samsung Galaxy S8+", Price = 4500 },
                    new Product { Name = "Samsung Galaxy S9", Price = 5000 },
                    new Product { Name = "Samsung Galaxy S9+", Price = 5500 },
                    new Product { Name = "Samsung Galaxy S10", Price = 6000 },
                    new Product { Name = "Samsung Galaxy S10+", Price = 6500 }
                };

                db.Products.AddRange(products);

                db.SaveChanges();

                System.Console.WriteLine("Datas added to database");

            }

        }

        static void AddProduct()
        {
            using (var db = new ShopContext())
            {
                var p = new Product { Name = "Samsung Galaxy S8", Price = 4000 };

                db.Products.Add(p);

                db.SaveChanges();

                System.Console.WriteLine("Data added to database");

            }
        }

    }
}
