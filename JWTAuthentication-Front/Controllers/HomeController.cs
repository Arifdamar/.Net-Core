using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication_Front.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}