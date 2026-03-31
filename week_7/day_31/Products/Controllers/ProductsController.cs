using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Products.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
     
        private static List<dynamic> products = new List<dynamic>();

        
        [HttpGet("index")]
        public IActionResult Index()
        {
            ViewBag.Products = products;
            return View();
        }

   
        [HttpPost("add")]
        public IActionResult Add(string name, double price, int quantity)
        {
            var product = new
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };

            products.Add(product);

            ViewBag.Products = products;

            return View("Index");
        }
    }
}
