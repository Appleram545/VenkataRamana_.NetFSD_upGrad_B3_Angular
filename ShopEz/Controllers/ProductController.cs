using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopEz.DTOs;
using ShopEz.Services;

namespace ShopEz.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await service.GetById(id));
        }

        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(ProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await service.Add(dto));
        }

   
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await service.Update(id, dto));
        }

        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.Delete(id));
        }
    }
}