using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Products.Models;

public class ProductsController : Controller
{
    public List<Product>pro = new List<Product>()
    {
        new Product{Id=1,Name="MacBook",Price=65000,Category="laptop"},
        new Product{Id=2,Name="Iphone 17 Pro Max",Price=145000,Category="Phone"},
        new Product{Id=3,Name="IWatch",Price=45000,Category="Watch"},
        new Product{Id=4,Name="Airpods 3",Price=65000,Category="Ear Buds"}
    };

    public IActionResult Index()
    {
        return View(pro);
    }
    public IActionResult Details(int id)
    {
        var product =pro.FirstOrDefault(p=>p.Id==id); // linq method

        return View(product);
    }
}