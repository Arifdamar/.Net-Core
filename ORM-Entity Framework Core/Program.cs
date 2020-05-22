using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory
        = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLoggerFactory(MyLoggerFactory)
            //.UseSqlite("Data Source=shop.db");
            //.UseSqlServer(@"Data Source=.\SQLEXPRESS; Initial Catalog=ShopDb; Integrated Security=SSPI;");
            .UseMySql(@"server=localhost;port=3306;database=ShopDb;user=root;password=123456789");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasIndex(u => u.Username)
                        .IsUnique();

            modelBuilder.Entity<Customer>()
                        .Property(p => p.IdentityNumber)
                        .HasMaxLength(11)
                        .IsRequired();

            modelBuilder.Entity<ProductCategory>()
                        .HasKey(t => new { t.ProductId, t.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                        .HasOne(pc => pc.Product)
                        .WithMany(p => p.ProductCategories)
                        .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                        .HasOne(pc => pc.Category)
                        .WithMany(c => c.ProductCategories)
                        .HasForeignKey(pc => pc.CategoryId);
        }
    }

    public static class DataSeeding
    {
        public static void Seed(DbContext context)
        {
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                // ShopContext
                if (context is ShopContext)
                {
                    ShopContext _context = context as ShopContext;

                    if (_context.Products.Count() == 0)
                    {
                        // add products
                        _context.Products.AddRange(products);
                    }

                    if (_context.Categories.Count() == 0)
                    {
                        // add categories
                        _context.Categories.AddRange(categories);
                    }
                }
                
                context.SaveChanges();
            }
        }

        private static Product[] products =
        {
            new Product(){Name = "Samsung Galaxy S8", Price =4000},
            new Product(){Name = "Samsung Galaxy S8+", Price =4500},
            new Product(){Name = "Samsung Galaxy S9", Price =5000},
            new Product(){Name = "Samsung Galaxy S9+", Price =5500},
            new Product(){Name = "Samsung Galaxy S10", Price =6000},
            new Product(){Name = "Samsung Galaxy S10+", Price =6500}
        };
        private static Category[] categories =
        {
            new Category(){Name = "Phone"},
            new Category(){Name = "Electronics"},
            new Category(){Name = "Computer"}
        };
    }

    public class User
    {
        public User()
        {
            this.Addresses = new List<Address>();
        }
        public int Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(20)]
        public string Username { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Email { get; set; }

        public Customer Customer { get; set; }

        public List<Address> Addresses { get; set; } // navigation property
    }

    public class Customer
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }

    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
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
        public string Name { get; set; }
        public decimal Price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;

        public List<ProductCategory> ProductCategories { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }

    public class ProductCategory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DataSeeding.Seed(new ShopContext());
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
