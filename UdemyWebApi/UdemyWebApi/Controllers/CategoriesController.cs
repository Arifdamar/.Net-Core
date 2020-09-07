using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyWebApi.DAL.Context;
using UdemyWebApi.DAL.Entities;

namespace UdemyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using var context = new UdemyWebApiContext();

            return Ok(context.Categories.ToList());
        }
    }
}
