using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Calculator.Controllers
{
    [Route("cal")]
    public class CalculatoorController : Controller
    {
        

       [HttpGet("add")]
       public IActionResult Add()
       {
         
         return View();
       }

        [HttpPost("add")]
       public IActionResult Add(int n1,int n2)
       {
        int result = n1+n2;

        ViewData["Result"]=result;

         return View("Add");
       }
       
    }
}