using Microsoft.AspNetCore.Mvc;

namespace shopapp.webui.Controllers
{
    public class ProductController: Controller
    {
        // localhost:5000/product/list
        public string List()
        {
            return "Product/List";
        }

        // localhost:5000/product/details
        public string Details()
        {
            return "Product/Details";
        }
    }
}