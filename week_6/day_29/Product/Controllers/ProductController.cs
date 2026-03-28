using System.ComponentModel.Design;
using Microsoft.AspNetCore.Mvc;
using Product.Models;


public class ProductController : Controller
{
    
    public static List<ProductItems>pro=new List<ProductItems>
    {
        new ProductItems{productId=1,name="MacBook Air",price=75000,category="Laptop"},
         new ProductItems{productId=2,name="Iphone 17",price=78000,category="Mobile"},
          new ProductItems{productId=3,name="Apple Ipad",price=75000,category="Ipad"},
           new ProductItems{productId=4,name="MacBook Pro",price=123000,category="Laptop"},
            new ProductItems{productId=5,name="Iphone Air",price=111000,category="Mobile"},
    };


    public IActionResult Index()
    {

        return View(pro);
    }


  
    public IActionResult Details(int id)
    {
        ProductItems  p= pro.FirstOrDefault(x=>x.productId==id);
        return View(p);
    }

    
    [HttpGet]
   public IActionResult Add()
   {
       // TODO: Your code here
       return View();
   }

   [HttpPost]
   public IActionResult Add( ProductItems obj)
   {
        // TODO: Your code her
        if (!ModelState.IsValid)
        {
            return View(obj);
        }

       pro.Add(obj);
       return RedirectToAction("Index");
   }

    [HttpGet]
    public IActionResult Edit(int id)
   {
       ProductItems pr= pro.FirstOrDefault(x=>x.productId==id);
       return View(pr);
   }
    [HttpPost]
public IActionResult Edit(ProductItems pr)
{

        if (!ModelState.IsValid)
        {
            return View(pr);
        }
        var ExistProduct=pro.FirstOrDefault(x=>x.productId==pr.productId);

       if(ExistProduct != null)
        {
            ExistProduct.name = pr.name;
            ExistProduct.price = pr.price;
            ExistProduct.category = pr.category;
        }

        return RedirectToAction("Index");

    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        ProductItems p= pro.FirstOrDefault(x=>x.productId==id);
        return View(p);
    }
    
    [HttpPost]
    [ActionName("Delete")]
    public IActionResult Deletey(int id)
    {
        ProductItems p = pro.FirstOrDefault(x=>x.productId==id);

        pro.Remove(p);
        return RedirectToAction("Index");
    }
    

  



}
