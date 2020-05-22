using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ORM_Entity_Framework_Core.Data.EfCore;

namespace ORM_Entity_Framework_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                // // get all customers
                // var customers = db.Customers.ToList();

                // foreach (var customer in customers)
                // {
                //     System.Console.WriteLine(customer.FirstName + " " + customer.LastName);
                // }

                // // get only first_name and last_name columns from customers table
                // var customers = db.Customers.Select(c => new {
                //     c.FirstName,
                //     c.LastName
                // });

                // foreach (var customer in customers)
                // {
                //     System.Console.WriteLine(customer.FirstName + " " + customer.LastName);
                // }

                // // get customers that live in New York and order by name
                // var customers = db.Customers
                //     .Where(c => c.City == "New York")
                //     .Select(c => new { c.FirstName, c.LastName })
                //     .OrderBy(c => c.FirstName)
                //     .ToList();

                // foreach (var customer in customers)
                // {
                //     System.Console.WriteLine(customer.FirstName + " " + customer.LastName);
                // }

                // // get product names that category name is "Beverages"
                // var productNames = db.Products
                //         .Where(p => p.Category == "Beverages")
                //         .Select(p => p.ProductName)
                //         .ToList();

                // foreach (var productName in productNames)
                // {
                //     System.Console.WriteLine(productName);
                // }

                // // get 5 last added products
                // var ProductNames = db.Products
                //             .OrderByDescending(p => p.Id)
                //             .Select(p => p.ProductName)
                //             .Take(5)
                //             .ToList();

                // foreach (var ProductName in ProductNames)
                // {
                //     System.Console.WriteLine(ProductName);
                // }

                // // get products' names and prices that prices are between 10 and 30 by descending
                // var products = db.Products
                //                 .Where(p => p.ListPrice > 10 && p.ListPrice < 30)
                //                 .Select(p => new { p.ProductName, p.ListPrice})
                //                 .OrderBy(p => p.ListPrice)
                //                 .ToList();
                
                // foreach (var product in products)
                // {
                //     System.Console.WriteLine(product.ProductName + " " + product.ListPrice);
                // }
            
                // // what is the average price of "Beverages" category
                // var average = db.Products
                //             .Where(p => p.Category == "Beverages")
                //             .Average(p => p.ListPrice);
                // System.Console.WriteLine(average);
            
                // // how many products are in "Beverages" category
                // var count = db.Products.Count(p => p.Category == "Beverages");
                // System.Console.WriteLine(count);

                // // what is the total price of products in category "Beverages" or "Condiments"
                // var total = db.Products
                //         .Where(p => p.Category == "Beverages" || p.Category == "Condiments")
                //         .Sum(p => p.ListPrice);
                // System.Console.WriteLine(total);

                // // get products that includes 'Tea' in ProductName
                // var products = db.Products.Where(p => p.ProductName.ToLower().Contains("tea")).ToList();
                
                // foreach (var product in products)
                // {
                //     System.Console.WriteLine(product.ProductName);
                // }

                // what is the most and least expensive product
                var max = db.Products.Max(p => p.ListPrice);
                                
                var min = db.Products.Min(p => p.ListPrice);

                System.Console.WriteLine(max);
                System.Console.WriteLine(min);

                var mostExpProduct = db.Products.Where( p => p.ListPrice == max).FirstOrDefault();
            
                var leastExpProduct = db.Products.Where( p => p.ListPrice == min).FirstOrDefault();

                System.Console.WriteLine("The most expensive products is: " + mostExpProduct.ProductName);
                System.Console.WriteLine("The least expensive products is: " + leastExpProduct.ProductName);
            }

        }
    }
}
