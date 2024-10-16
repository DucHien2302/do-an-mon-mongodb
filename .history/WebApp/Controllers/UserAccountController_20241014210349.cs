using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using WebApp.Models;

namespace WebApp.Controllers;

public class UserAccountController : Controller
{
    UserAccountRepository userAccountRepository;
    ExperienceDetailRepository experienceDetailRepository;
    EducationDetailRepository educationDetailRepository;
    public UserAccountController(IMongoDBConnection connection)
    {
        userAccountRepository = new UserAccountRepository(connection);
        educationDetailRepository = new EducationDetailRepository(connection);
        experienceDetailRepository = new ExperienceDetailRepository(connection);
    }
    public IActionResult Index()
    {
        return View(userAccountRepository.GetUserAccount(User?.FindFirst(ClaimTypes.Email).Value));
    }
    [HttpPost]
    public async Task<IActionResult> Update(UserAccount obj, IFormFile f)
    {
        if (f != null)
        {
            string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
            if (!string.IsNullOrEmpty(obj.UserImage))
            {

                if (System.IO.File.Exists(Path.Combine(root, obj.UserImage)))
                {
                    System.IO.File.Delete(Path.Combine(root, obj.UserImage));
                };
            }
            string ext = Path.GetExtension(f.FileName);
            obj.UserImage = Helper.RandomString(32 - ext.Length) + ext;
            using (Stream stream = new FileStream(Path.Combine(root, obj.UserImage), FileMode.Create))
            {
                f.CopyTo(stream);
            }
        }
        UserAccount user = await userAccountRepository.GetUserAccount(ObjectId.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        if (user != null)
        {
            var ret = await userAccountRepository.UpdateUserAccountAsync(ObjectId.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)), obj);
            if (ret)
            {
                TempData["Msg"] = "Update Success";
            }
            else
            {
                TempData["Msg"] = "Update Failed";
            }
        }
        return Redirect("/useraccount");
    }
    public IActionResult AddEducationDetail()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddEducationDetail(EducationDetail obj)
    {
        if (ModelState.IsValid)
        {
            await educationDetailRepository.Add(ObjectId.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier.ToString())), obj);

            TempData["Msg"] = "Add Success";
            return Redirect("/useraccount");
        }
        TempData["Msg"] = "Add Failed";
        return View(obj);
    }
    public IActionResult AddExperienceDetail()
    {
        return View();
    }
    [HttpPost]

}