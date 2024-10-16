using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Authorize]
public class UserAccountController : Controller
{
    UserAccountRepository userAccountRepository;
    public UserAccountController(IMongoDBConnection connection)
    {
        userAccountRepository = new UserAccountRepository(connection);
    }
    public IActionResult Index()
    {
        return View(userAccountRepository.GetUserAccount(User.FindFirst(ClaimTypes.Email).Value));
    }
}