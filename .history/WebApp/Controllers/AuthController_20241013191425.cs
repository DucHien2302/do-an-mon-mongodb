using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController : Controller
{
    UserTypeRepository userTypeRepository;
    UserRegisterRepository userRegisterRepository;
    UserLoginRepository userLoginRepository;
    public AuthController(IMongoDBConnection connection)
    {
        userTypeRepository = new UserTypeRepository(connection);
        userRegisterRepository = new UserRegisterRepository(connection);
        userLoginRepository = new UserLoginRepository(connection);
    }
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(UserLogin obj)
    {
        try
        {
            if (ModelState.IsValid)
            {
                UserLogin user = userLoginRepository.GetUserLogin(obj);
            }
            TempData["Msg"] = "Login Success";
            return Redirect("/auth/about");
        }
        catch
        {
            TempData["Msg"] = "Register Failed!";
        }
        return View(obj);
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
            TempData["Msg"] = "Register Success";
            return Redirect("/auth/login");
        }
        catch
        {
            TempData["Msg"] = "Register Failed!";
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