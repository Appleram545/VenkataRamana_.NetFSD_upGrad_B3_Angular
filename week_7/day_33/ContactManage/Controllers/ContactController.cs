using Microsoft.AspNetCore.Mvc;
using ContactManage.Models;
using ContactManage.Repository;

namespace ContactManage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        // GET: api/contact
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAllContacts());
        }

        // GET: api/contact/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _repo.GetContactById(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        // POST: api/contact
        [HttpPost("AddContact")]
        public IActionResult Add(ContactInfo contact)
        {
            _repo.AddContact(contact);
            return Ok(contact);
        }

        // PUT: api/contact/5
        [HttpPut("EditContact")]
        public IActionResult Update(int id, ContactInfo contact)
        {
            if (id != contact.ContactId) return BadRequest();
            _repo.UpdateContact(contact);
            return Ok();
        }

        // DELETE: api/contact/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.DeleteContact(id);
            return Ok();
        }
    }
}