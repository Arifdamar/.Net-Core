using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JWTAuthentication_Front.ApiServices.Concrete;
using JWTAuthentication_Front.ApiServices.Interfaces;
using JWTAuthentication_Front.Models;

namespace JWTAuthentication_Front.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLogin appUserLogin)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.LogIn(appUserLogin))
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "kullanıcı adı veya şifre hatalı");
            }
            return View(appUserLogin);
        }

    }
}