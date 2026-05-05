using Microsoft.AspNetCore.Mvc;
using ShopEz.Models;
using ShopEz.DTOs;
using ShopEz.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized("User not authenticated.");
            if (!int.TryParse(userIdClaim, out int userId)) return Unauthorized("Invalid user token.");

            try { return Ok(await service.Create(dto, userId)); }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
            catch (InvalidOperationException ex) { return Conflict(ex.Message); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var roleClaim = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userIdClaim == null) return Unauthorized();
            if (!int.TryParse(userIdClaim, out int userId)) return Unauthorized();

            try
            {
                if (roleClaim?.ToLower() == "admin")
                    return Ok(await service.GetAll()); // Admin sees all other orders
                else
                    return Ok(await service.GetByUserId(userId)); // Customer sees own orders
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest("Order ID must be greater than 0.");
            try { return Ok(await service.GetById(id)); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }
    }
}