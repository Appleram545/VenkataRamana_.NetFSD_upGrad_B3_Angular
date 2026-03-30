using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AbcInfotech.Models;

namespace AbcInfotech.Controllers
{
   
    public class ContactController : Controller
    {
        public static List<ContactInfo> contacts= new List<ContactInfo>();

       

        public IActionResult ShowDetails()
        {
           
            return View(contacts);
        }


        [HttpGet]
        public IActionResult AddContact()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo obj)
        {

            if (ModelState.IsValid)
            {
                contacts.Add(obj);
                return RedirectToAction("ShowDetails");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Search()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Search(int id)
        {
            var res = contacts.FirstOrDefault(c=>c.ContactId==id);

            if (res == null)
            {
                ViewBag.Message="Contact Not Available";
                
            }
            return View("SearchedResult",res);
        }
        
        
        
        
    }
}