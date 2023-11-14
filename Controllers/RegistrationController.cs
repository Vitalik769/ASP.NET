using Microsoft.AspNetCore.Mvc;
using System;
using Lr_10.Models;
public class RegistrationController : Controller
{
    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registration(RegistrationModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Success"); 
        }
        return View(model);
    }
}
