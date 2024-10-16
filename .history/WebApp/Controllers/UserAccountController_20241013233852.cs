using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class UserAccountController : Controller
{
    UserAccountRepository userAccountRepository;
    public UserAccountController(IMongoDBConnection connection)
    {
        userAccountRepository = new UserAccountRepository(connection);
    }
    public IActionResult Index()
    {

    }
}