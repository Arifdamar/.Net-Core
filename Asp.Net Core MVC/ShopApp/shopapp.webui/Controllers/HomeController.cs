using Microsoft.AspNetCore.Mvc;

namespace shopapp.webui.Controllers
{
    public class HomeController: Controller
    {

        // localhost:5000/home/index
        public string Index()
        {
            return "Home/Index";
        }
        
        // localhost:5000/home/about
        public string About()
        {
            return "Home/About";
        }
    }
}