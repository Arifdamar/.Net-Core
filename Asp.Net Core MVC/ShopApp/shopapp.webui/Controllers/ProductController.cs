using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Models;
using shopapp.webui.ViewModels;

namespace shopapp.webui.Controllers
{
    public class ProductController : Controller
    {

        // localhost:5000/product/index
        public IActionResult Index()
        {

            var product = new Product { Name = "Samsung Galaxy S10", Price = 7000, Description = "Good phone" };

            // ViewData["Product"] = product;
            // ViewData["Category"] = "Phones";

            ViewBag.Category = "Phones";
            // ViewBag.Product = product;


            return View(product);
        }
        // localhost:5000/product/list
        public IActionResult List()
        {
            var products = new List<Product>()
            {
                new Product
                {
                    Name = "Samsung Galaxy S9",
                    Price = 6000,
                    Description = "Good Phone",
                    IsApproved = true
                },
                new Product
                {
                    Name = "Samsung Galaxy S9+",
                    Price = 6500,
                    Description = "Better Phone"
                },
                new Product
                {
                    Name = "Samsung Galaxy S8",
                    Price = 5000,
                    Description = "Better Phone"
                },
                new Product
                {
                    Name = "Samsung Galaxy S8+",
                    Price = 5500,
                    Description = "Better Phone",
                    IsApproved = true
                },
                new Product
                {
                    Name = "Samsung Galaxy S10+",
                    Price = 7500,
                    Description = "Better Phone",
                    IsApproved = true
                },
                new Product
                {
                    Name = "Samsung Galaxy S10",
                    Price = 7000,
                    Description = "Better Phone"
                }
            };

            var productViewModel = new ProductViewModel()
            {
                Products = products,
                Category = new Category()
                {
                    Name = "Phones",
                    Description = "All phones"
                }
            };

            return View(productViewModel);
        }

        // localhost:5000/product/details
        public IActionResult Details(int id)
        {

            var p = new Product();
            p.Name = "Samsung Galaxy S9";
            p.Price = 5000;
            p.Description = "Good phone";

            return View(p);
        }
    }
}