using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class AuthController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Resume()
    {

    }
}