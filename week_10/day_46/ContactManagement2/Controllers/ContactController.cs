using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using ContactManagement2.Interfaces;
using ContactManagement2.Models;
using Microsoft.Extensions.Logging;


namespace ContactManagement2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {

        private readonly IContactService _service;
        private readonly ILogger<ContactController> _logger;
        public  ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        public ContactController(IContactService service, ILogger<ContactController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Fetching all contacts");
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public IActionResult Add([FromBody] Contact contact)
        {
            _service.Add(contact);
            return StatusCode(201, contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Contact contact)
        {
            _service.Update(id, contact);
            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Deleted");
        }
    }
}