using System.Threading.Tasks;
using Arif.JWTAuthentication.Business.Interfaces;
using Arif.JWTAuthentication.Entities.Concrete;
using Arif.JWTAuthentication.Entities.Dtos.AppUserDtos;
using Arif.JWTAuthentication.WebApi.CustomFilters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Arif.JWTAuthentication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AuthController(IJwtService jwtService, IAppUserService appUserService, IMapper mapper)
        {
            _jwtService = jwtService;
            _appUserService = appUserService;
            _mapper = mapper;
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
                var roles = await _appUserService.GetRolesByUserNameAsync(appUserLoginDto.UserName);
                var token = _jwtService.GenerateJwt(appUser, roles);

                return Created("", token);
            }

            return BadRequest("Kullanıcı Adı Veya Şifre Hatalı");
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> Register(AppUserRegisterDto appUserRegisterDto)
        {
            var appUser = await _appUserService.FindByUserName(appUserRegisterDto.UserName);

            if (appUser != null)
            {
                return BadRequest($"{appUserRegisterDto.UserName} Kullanıcı Adı Zaten Alınmış");
            }

            await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserRegisterDto));

            return Created("", appUserRegisterDto);
        }
    }
}
