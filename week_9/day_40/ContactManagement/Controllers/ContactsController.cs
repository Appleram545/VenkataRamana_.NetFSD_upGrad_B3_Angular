using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactManagement.Models;

namespace ContactManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly AppDbContext _context;


        public ContactsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
            => Ok(_context.Contacts.ToList());


        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_context.Contacts.Find(id));


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok(contact);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, Contact updated)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) return NotFound();

            contact.Name = updated.Name;
            contact.Email = updated.Email;
            contact.Phone = updated.Phone;

            _context.SaveChanges();
            return Ok(contact);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null) return NotFound();

            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok("Deleted");
        }



    }
}