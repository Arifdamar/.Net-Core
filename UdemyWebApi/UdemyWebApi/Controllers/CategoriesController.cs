using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyWebApi.DAL.Context;
using UdemyWebApi.DAL.Entities;
using UdemyWebApi.Services;

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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using var context = new UdemyWebApiContext();
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            using var context = new UdemyWebApiContext();
            var categoryToUpdate = context.Categories.Find(category.Id);

            if (categoryToUpdate == null)
            {
                return NotFound();
            }

            categoryToUpdate.Name = category.Name;
            context.Update(categoryToUpdate);
            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var context = new UdemyWebApiContext();
            var categoryToDelete = context.Find<Category>(id);

            if (categoryToDelete == null)
            {
                return NotFound();
            }

            context.Remove(categoryToDelete);
            context.SaveChanges();

            return NoContent();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            using var context = new UdemyWebApiContext();
            context.Categories.Add(category);
            context.SaveChanges();

            return Created("", category);
        }

        [HttpGet("{id}/blogs")]
        public IActionResult GetWithBlogsById(int id)
        {
            using var context = new UdemyWebApiContext();
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryWithBlogs = context.Categories.Where(I => I.Id == id).Include(I => I.Blogs).ToList();

            return Ok(categoryWithBlogs);
        }


        //[HttpGet("[action]")]
        //public IActionResult Test([FromRoute] int id) api/categories/test/1
        //[HttpGet("[action]/{id}")]
        //public IActionResult Test([FromQuery] int id) api/categories/test?id=1
        [HttpGet("[action]")]
        public IActionResult Test([FromServices] IUserService userService)
        {
            //var value = HttpContext.Request.Headers["Authentication"];
            //var value = HttpContext.Request.Form["Auth"];

            var name = userService.GetName("Arif Damar");

            return Ok(name);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            var newFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents", newFileName);
            var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            return Created("", file);
        }
    }
}
