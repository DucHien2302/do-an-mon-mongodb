using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController : Controller
{
    UserAccountRepository userAccountRepository;
    UserTypeRepository userTypeRepository;
    public AuthController(IMongoDBConnection connection)
    {
        userTypeRepository = new UserTypeRepository(connection);
        userAccountRepository = new UserAccountRepository(connection);
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
                UserAccount user = userAccountRepository.GetUserLogin(obj);
                if (user != null)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.MobilePhone, user.ContactNumber)
                    };
                    TempData["Msg"] = "Login Success";
                    return Redirect("/auth/about");
                }
            }
        }
        catch
        {
            TempData["Msg"] = "Login Failed!";
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
                userAccountRepository.Register(obj);
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
    [Authorize]
    public IActionResult About()
    {
        return View();
    }
    [Authorize]
    public IActionResult Resume()
    {
        return View();
    }
    public IActionResult Error()
    {
        return View();
    }
}