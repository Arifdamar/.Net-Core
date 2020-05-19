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
            GetProductsByName("S10");
        }
        
        static void GetProductsByName(string name)
        {
            using (var context = new ShopContext())
            {
                var products = context
                                .Products
                                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                                .Select(p => new
                                        {
                                            p.Name,
                                            p.Price
                                        })
                                .ToList();

                foreach (var p in products)
                {
                    Console.WriteLine($"name: {p.Name}, price: {p.Price}");
                }
            }
        }

        static void GetProductById(int id)
        {
            using (var context = new ShopContext())
            {
                var product = context
                                .Products
                                .Where(p => p.Id == id)
                                .Select(p => new
                                        {
                                            p.Name,
                                            p.Price
                                        })
                                .FirstOrDefault();

                if (product != null)
                {
                    Console.WriteLine($"name: {product.Name}, price: {product.Price}");
                }
            }
        }
        static void GetAllProducts()
        {
            using (var context = new ShopContext())
            {
                var products = context
                .Products
                .Select(product => new
                {
                    product.Name,
                    product.Price
                })
                .ToList();

                foreach (var p in products)
                {
                    Console.WriteLine($"name: {p.Name}, price: {p.Price}");
                }

            }
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
