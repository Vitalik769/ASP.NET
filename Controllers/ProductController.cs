using Microsoft.AspNetCore.Mvc;

namespace AspNetMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View("./Views/ProductWeather/Index.cshtml");
        }
    }
}