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
        public DbSet<Order> Orders { get; set; }

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

    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AddProducts();
        }

        static void DeleteProduct(int id)
        {
            using (var db = new ShopContext())
            {
                var p = new Product(){Id = id};

                // db.Products.Remove(p);
                db.Entry(p).State = EntityState.Deleted;

                db.SaveChanges();

                // var p = db.Products.FirstOrDefault(i => i.Id == id);

                // if(p != null)
                // {
                //     db.Products.Remove(p);
                //     db.SaveChanges();

                //     System.Console.WriteLine("Data deleted successfully");
                // }
            }
        }
        static void UpdateProduct()
        {
            using (var db = new ShopContext())
            {
                var p = db.Products.Where(i => i.Id == 1).FirstOrDefault();

                if (p != null)
                {
                    p.Price *= 1.2m;

                    db.Products.Update(p);
                    db.SaveChanges();
                }



                // var p = db
                // .Products
                // .Where(i => i.Id == 1)
                // .FirstOrDefault();

                // if (p != null)
                // {
                //     p.Price *= 1.2m;

                //     db.SaveChanges();

                //     Console.WriteLine("Updated");
                // }
            }
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
