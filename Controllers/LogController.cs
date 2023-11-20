using Lr_11.Filters;
using Microsoft.AspNetCore.Mvc;

[ServiceFilter(typeof(ActionFilter))] 
public class LogController : Controller
{
    public async Task<IActionResult> Index()
    {
        
        return View();
    }

    public async Task<IActionResult> About()
    {
        
        return View();
    }

    
}
