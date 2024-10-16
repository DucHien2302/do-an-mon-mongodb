using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController : Controller
{
    UserTypeRepository userTypeRepository;
    public AuthController(UserTypeRepository userTypeRepository)
    {
        this.userTypeRepository = userTypeRepository;
    }
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Register()
    {
        ViewBag.userTypes
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Resume()
    {
        return View();
    }
}