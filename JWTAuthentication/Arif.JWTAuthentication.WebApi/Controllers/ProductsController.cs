using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arif.JWTAuthentication.Business.Interfaces;
using Arif.JWTAuthentication.Entities.Concrete;
using Arif.JWTAuthentication.Entities.Dtos.ProductDtos;
using Arif.JWTAuthentication.WebApi.CustomFilters;
using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arif.JWTAuthentication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(product);
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            
            await _productService.AddAsync(_mapper.Map<Product>(productAddDto));

            return Created("", productAddDto);
        }

        [HttpPut]
        [ValidModel]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productUpdateDto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.RemoveAsync(await _productService.GetByIdAsync(id));

            return NoContent();
        }

        [Route("/Error")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            // logging
            return Problem(detail: "An error occured");
        }
    }
}
