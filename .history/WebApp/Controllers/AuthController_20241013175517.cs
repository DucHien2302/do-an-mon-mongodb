using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController : Controller
{
    UserTypeRepository userTypeRepository;
    public AuthController(IMongoDBConnection connection)
    {
        userTypeRepository = new UserTypeRepository(connection);
    }
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Register()
    {
        ViewBag.userTypes = userTypeRepository.GetUserTypes();
        return View();
    }
    [HttpPost]
    public IActionResult Register(UserRegister obj)
    {

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