using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactManagement.Models;
using ContactManagement.DataAccess;

namespace ContactManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = _repository.GetAllContacts();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {

            var contact = _repository.GetContactById(id);

            if(contact == null)
            {
                return NotFound("No contact is available ");
            }
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
        var add = _repository.AddContact(contact);
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id,ContactInfo contact)
        {
            var update = _repository.GetContactById(id);

            if(update == null)
            {
                return NotFound("Not able to update");
            }
            _repository.UpdateContact(id, contact);
            return Ok("Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var del = _repository.GetContactById(id);


            if(del == null)
            {
                return NotFound("No contact is there to delete");
            }

            _repository.DeleteContact(id);
            return Ok("Deleted Successfully");
        }
        
        
        


        
    }
}