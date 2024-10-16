using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "AITILO";
        return View();
    }
    public IActionResult Contact()
    {
        ViewData["Address"] = "";
        return View();
    }
}