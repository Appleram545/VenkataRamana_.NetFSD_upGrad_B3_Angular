using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Models;
using Products.Repositories;


namespace Products.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }



        public IActionResult Details(int id)
        {
            var prodObj = _repo.GetById(id);
            return View(prodObj);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(product);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Product details.";
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var product = _repo.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }


        public IActionResult Delete(int id)
        {
            var product = _repo.GetById(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}