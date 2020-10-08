using System.Threading.Tasks;
using Arif.JWTAuthentication.Business.Interfaces;
using Arif.JWTAuthentication.Entities.Dtos.AppUserDtos;
using Arif.JWTAuthentication.WebApi.CustomFilters;
using Microsoft.AspNetCore.Mvc;

namespace Arif.JWTAuthentication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;

        public AuthController(IJwtService jwtService, IAppUserService appUserService)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
        }

        [HttpGet("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserService.FindByUserName(appUserLoginDto.UserName);

            if (appUser == null)
            {
                return BadRequest("Kullanıcı Adı Veya Şifre Hatalı");
            }

            if (await _appUserService.CheckPassword(appUserLoginDto))
            {
                var token = _jwtService.GenerateJwt(appUser, await _appUserService.GetRolesByUserNameAsync(appUserLoginDto.UserName));

                return Created("", token);
            }

            return BadRequest("Kullanıcı Adı Veya Şifre Hatalı");
        }
    }
}
