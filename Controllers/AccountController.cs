using Microsoft.AspNetCore.Mvc;

namespace Lesson2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login -> Hiển thị form đăng nhập
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login -> Xử lý dữ liệu khi bấm nút Submit
        [HttpPost]
        public string Login(string username, string password)
        {
            if (username == "admin" && password == "123")
            {
                return "Login success";
            }
            return "Login failed";
        }
    }
}