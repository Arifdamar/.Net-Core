using Microsoft.AspNetCore.Mvc;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class ProductController: Controller
    {
        
        // localhost:5000/product/index
        public IActionResult Index()
        {
            return View();
        }
        // localhost:5000/product/list
        public IActionResult List()
        {
            return View();
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