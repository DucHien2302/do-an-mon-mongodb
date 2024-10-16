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
        ViewData["Address"] = "140 Lê Trọng Tấn, Tây Thạnh, Tân Phú, TP.Hồ Chí Minh";
        ViewData["Phone"] = "0333172xxx";
        return View();
    }
}