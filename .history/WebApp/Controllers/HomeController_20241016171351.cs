using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    IEmailSender sender;
    public HomeController()
    public IActionResult Index()
    {
        ViewData["Title"] = "AITILO";
        return View();
    }
    public IActionResult Contact()
    {
        ViewData["Address"] = "140 Lê Trọng Tấn, Tây Thạnh, Tân Phú, TP.Hồ Chí Minh";
        ViewData["Phone"] = "+84 331 72xxx";
        ViewData["Email"] = "nguyenduchien@gmail.com";
        return View();
    }
}