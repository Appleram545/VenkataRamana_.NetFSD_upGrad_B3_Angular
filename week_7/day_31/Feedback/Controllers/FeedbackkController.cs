using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Feedback.Controllers
{
    [Route("feedback")]
    public class FeedbackkController : Controller
    {

        [HttpGet("form")]
        public IActionResult Form()
        {
            return View();
        }

        // POST → Handle submission
        [HttpPost("submit")]
        public IActionResult Submit(string name, string comments, int rating)
        {
            string message;

            if (rating >= 4)
            {
                message = "Thanks for  feedback ";
            }
            else
            {
                message = "We will improve ";
            }

            ViewData["Message"] = message;

            return View("Form");
        }

    }
}