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
    }
}
