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
    public class CustomerModel
    {
        public CustomerModel()
        {
            this.Orders = new List<OrderModel>();
        }
        public string FullName { get; set; }
        public int OrderCount { get; set; }
        public List<OrderModel> Orders { get; set; }
    }

    public class OrderModel
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public List<ProductModel> Products { get; set; }
    }

    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                var customers = db.Customers
                            .Where(c => c.Orders.Count() > 0) // or c.Orders.Any()
                            .Select(c => new CustomerModel()
                            {
                                FullName = c.FirstName + " " + c.LastName,
                                OrderCount = c.Orders.Count(),
                                Orders = c.Orders.Select(o => new OrderModel()
                                {
                                    OrderId = o.Id,
                                    Total = (decimal)o.OrderDetails.Sum(od => od.Quantity * od.UnitPrice),
                                    Products = o.OrderDetails.Select(od => new ProductModel
                                                                {
                                                                    ProductId = (int)od.ProductId,
                                                                    Name = od.Product.ProductName
                                                                }).ToList()
                                }).ToList()
                            })
                            .OrderByDescending(cm => cm.OrderCount)
                            .ToList();

                foreach (var customer in customers)
                {
                    System.Console.WriteLine($"{customer.FullName} has {customer.OrderCount} orders\n{{");
                    foreach (var order in customer.Orders)
                    {
                        System.Console.WriteLine($"    Total price of the order with an id of {order.OrderId} is {order.Total}");
                        foreach (var product in order.Products)
                        {
                            System.Console.WriteLine($"        [Product Name: {product.Name}]");
                        }
                    }
                    System.Console.WriteLine("}\n");
                }
            }

        }
    }
}
