using Microsoft.AspNetCore.Mvc;
using login.Models;



public class LoginController: Controller
{

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(Login model)
    {
        if(model.Username =="admin" && model.Password == "1234")
        {
            return Content("Login Successful ");
        }

        ViewBag.Error = "Invalid Username or Password ";
        return View();
    }
}


