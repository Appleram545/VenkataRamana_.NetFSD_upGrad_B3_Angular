using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactService.Services;
using Microsoft.AspNetCore.Authorization;
using ContactService.DTOs;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _service.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        [Authorize(Roles="Admin")]
        public IActionResult Add(ContactDto dto)
        {
            _service.Add(dto);
            return Ok("Contact Added");
        }

        [HttpPut("{id}")]
        [Authorize(Roles="Admin")]
        public IActionResult Update(int id, ContactDto dto)
        {
            _service.Update(id,dto);
            return Ok("COntact Updatedd");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles="Admin")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("COntact DElated");
        }
        
        
        
        
        
    }
}
