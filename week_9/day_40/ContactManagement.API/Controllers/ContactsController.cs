using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactManagement.API.Exceptions;

namespace ContactManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           _logger.LogInformation("Geting Details By id{id}",id);

            if (id <= 0)
                throw new BadRequestException("Invalid ");

            if (id == 999)
                throw new NotFoundException(" not found");

            return Ok(new { Id = id, Name = " Contact" });
        }

        [HttpPost]
        public IActionResult Create()
        {
            _logger.LogInformation("Contacxt Created");

            return Ok("Contect Created Sucessfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            _logger.LogInformation("Contact updated with ID {Id}", id);
            return Ok("Contact updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Contact deleted with ID {Id}", id);
            return Ok("Contact deleted");
        }

    }
}