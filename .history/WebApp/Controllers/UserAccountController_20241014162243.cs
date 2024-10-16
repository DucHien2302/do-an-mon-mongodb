using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        return View(userAccountRepository.GetUserAccount(User?.FindFirst(ClaimTypes.Email).Value));
    }
    [HttpPost]
    public IActionResult Update(UserAccount obj, IFormFile f)
    {
        if (f != null)
        {
            string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
            if (System.IO.File.Exists(Path.Combine(root, obj.UserImage)))
            {
                System.IO.File.Delete(Path.Combine(root, obj.UserImage));
            };
            string ext = Path.GetExtension(f.FileName);
            obj.UserImage = Helper.RandomString(32 - ext.Length) + ext;
            using (Stream stream = new FileStream(Path.Combine(root, obj.UserImage), FileMode.Create))
            {
                f.CopyTo(stream);
            }
        }
        UserAccount user = userAccountRepository.GetUserAccount(User.FindFirstValue(ClaimTypes.NameIdentifier));
        if (user != null)
        {
            var ret = userAccountRepository.UpdateUserAccountAsync(ObjectId.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)), obj);
            if (ret)
        }
        return Redirect("/useraccount");

    }
}