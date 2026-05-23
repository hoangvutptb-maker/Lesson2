using Microsoft.AspNetCore.Mvc;

namespace Lesson2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Info()
        {
            // Truyền dữ liệu bằng 3 cách khác nhau
            ViewBag.Name = "Nguyễn Văn A";
            ViewData["Age"] = 20;
            string major = "Công nghệ thông tin - Đại học CMC";

            // Trả về giao diện và truyền biến major qua Model
            return View(model: major);
        }
    }
}