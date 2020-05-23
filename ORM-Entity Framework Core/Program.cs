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
            // using (var db = new NorthwindContext())
            // {
            //     var customers = db.Customers
            //             .FromSqlRaw("select * from customers where city='Miami'").ToList();
                
            //     foreach (var customer in customers)
            //     {
            //         System.Console.WriteLine(customer.FirstName);                    
            //     }
            // }

            using (var db = new CustomNorthwindContext())
            {
                var customers = db.CustomerOrders
                            .FromSqlRaw("select c.id, c.first_name, count(*) from customers c inner join orders o on c.id=o.customer_id group by c.id")
                            .ToList();
                foreach (var customer in customers)
                {
                    System.Console.WriteLine("Customer id: {0} First Name: {1} Order Count: {2}",customer.CustomerId, customer.Name, customer.Count);
                }
            }
        }
    }
}
