using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.JWTAuthentication.Business.Interfaces;
using Arif.JWTAuthentication.Entities.Dtos.AppUserDtos;
using Arif.JWTAuthentication.WebApi.CustomFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arif.JWTAuthentication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet("[action]")]
        [ValidModel]
        public IActionResult SignIn(AppUserLoginDto appUserLoginDto)
        {
            

            return Created("", "");
        }
    }
}
