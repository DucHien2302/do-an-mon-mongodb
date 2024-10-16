using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController : Controller
{
    UserTypeRepository userTypeRepository;
    UserRegisterRepository userRegisterRepository;
    public AuthController(IMongoDBConnection connection)
    {
        userTypeRepository = new UserTypeRepository(connection);
        userRegisterRepository = new UserRegisterRepository(connection);
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
        try
        {
            if (ModelState.IsValid)
            {
                userRegisterRepository.Register(obj);
            }
            ModelState.AddModelError("Msg", "Register Success");
        }
        catch
        {
            ModelState.AddModelError("Msg", "Register Failed");
        }
        return View(obj);
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