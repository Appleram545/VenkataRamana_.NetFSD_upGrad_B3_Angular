using Microsoft.AspNetCore.Mvc;
using ShopEz.Models;
using ShopEz.DTOs;
using ShopEz.Repositories;
using ShopEz.Services;
using Microsoft.AspNetCore.Authorization;

namespace ShopEz.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService service;

        public OrderController(IOrderService _service)
        {
            service = _service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDto dto)
            => Ok(await service.Create(dto));

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await service.GetById(id));
    }
}