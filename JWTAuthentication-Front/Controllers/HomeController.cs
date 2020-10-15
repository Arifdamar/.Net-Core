using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JWTAuthentication_Front.ApiServices.Interfaces;
using JWTAuthentication_Front.CustomFilters;
using JWTAuthentication_Front.Models;

namespace JWTAuthentication_Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductApiService _productApiService;

        public HomeController(IProductApiService productApiService)
        {
            _productApiService = productApiService;
        }
        [JwtAuthorize(Roles = "Admin,Member")]
        public async Task<IActionResult> Index()
        {

            return View(await _productApiService.GetAllAsync());
        }
        [JwtAuthorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [JwtAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ProductAdd productAdd)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.AddAsync(productAdd);
                return RedirectToAction("Index", "Home");
            }
            return View(productAdd);
        }
        [JwtAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {

            return View(await _productApiService.GetByIdAsync(id));
        }
        [HttpPost]
        [JwtAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(ProductList productList)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.UpdateAsync(productList);
                return RedirectToAction("Index", "Home");
            }
            return View(productList);
        }
        [JwtAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productApiService.DeleteAsync(id);
            return RedirectToAction("Index", "Home");
        }

    }
}