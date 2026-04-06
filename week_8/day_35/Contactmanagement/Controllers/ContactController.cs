using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Contactmanagement.Models;
using Contactmanagement.Repositories;

namespace Contactmanagement.Controllers
{
   
    public class ContactController : Controller
    {
        

       private readonly IContactRepository _repo;

       public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var contacts = _repo.GetAllContacts();
            return View(contacts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactInfo contact)
        {
            _repo.AddContact(contact);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = _repo.GetContactById(id);
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(ContactInfo contact)
        {
            _repo.UpdateContact(contact);
            return RedirectToAction("Index");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _repo.GetContactById(id);
            return View(contact);
        }

        [HttpPost("delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}