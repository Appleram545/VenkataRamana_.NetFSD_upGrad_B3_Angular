using Microsoft.AspNetCore.Mvc;
using ContactManagement.Models;
using ContactManagement.Services;

namespace ContactManagement.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }


        public IActionResult ShowContacts()
        {
            var contacts = _service.GetAllContacts();
            return View(contacts);
        }

 
        public IActionResult AddContact()
        {
            return View();
        }

 
        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            _service.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }
    }
}