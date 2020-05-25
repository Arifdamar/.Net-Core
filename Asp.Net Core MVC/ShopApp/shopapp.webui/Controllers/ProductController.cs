using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
    }
}