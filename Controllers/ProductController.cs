using AspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var product = new List<Product>
            {
                new Product { ID = 1, Name = "Audi Q7 2017", Price = 54.777, CreatedDate = DateTime.Now },
                new Product { ID = 2, Name = "BMW X5 2015", Price = 38.500, CreatedDate = DateTime.Now.AddMinutes(-15) },
                new Product { ID = 3, Name = "Mercedes-Benz C-Class 2016", Price = 27.999, CreatedDate = DateTime.Now.AddDays(-2) }
            };
            return View(product);
        }
    }
}
