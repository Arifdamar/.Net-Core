using System;
using Microsoft.AspNetCore.Mvc;

namespace shopapp.webui.Controllers
{
    public class HomeController : Controller
    {

        // localhost:5000/home/index
        public IActionResult Index()
        {
            ViewBag.Greeting = DateTime.Now.Hour < 12 ? "Good Morning" : "Have a good day";
            ViewBag.UserName = "Arif";

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