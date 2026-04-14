using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactManagement.Repositories;
using ContactManagement.Services;

namespace ContactManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = _service.GetAllContacts();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _service.GetContactById(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }
    }
}