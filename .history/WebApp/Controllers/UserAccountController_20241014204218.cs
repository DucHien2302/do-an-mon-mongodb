using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using WebApp.Models;

namespace WebApp.Controllers;

public class UserAccountController : Controller
{
    UserAccountRepository userAccountRepository;
    EducationDetailRepository educationDetailRepository;
    public UserAccountController(IMongoDBConnection connection)
    {
        userAccountRepository = new UserAccountRepository(connection);
        educationDetailRepository = new EducationDetailRepository(connection);
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
    public IActionResult AddEducationDetail(EducationDetail obj)
    {
        if (ModelState.IsValid)
        {
            // Giả sử bạn có service để thêm chi tiết giáo dục vào cơ sở dữ liệu
            educationDetailRepository.Add(ObjectId.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier.ToString())), obj);

            // Sau khi thêm thành công, có thể chuyển hướng đến một trang khác
            return RedirectToAction(); // Chuyển hướng về trang chủ hoặc trang khác sau khi thêm thành công
        }
        return View(obj); // Nếu có lỗi, trả về lại View với dữ liệu đã nhập
    }
}