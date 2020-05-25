using Microsoft.AspNetCore.Mvc;

namespace shopapp.webui.Controllers
{
    public class HomeController: Controller
    {

        // localhost:5000/home/index
        public IActionResult Index()
        {
            return View();
        }
        
        // localhost:5000/home/about
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View("MyView");
        }
    }
}