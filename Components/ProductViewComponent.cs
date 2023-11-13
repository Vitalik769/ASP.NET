using Microsoft.AspNetCore.Mvc;
using AspNetMVC.Models;

namespace AspNetMVC.Components
{
    public class ProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Product> products)

        {
            return View("/Views/ProductWeather/ProductTable.cshtml", products);

        }
    }
}