using Microsoft.AspNetCore.Mvc;

namespace Lesson2.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Welcome to ASP.NET MVC";
        }

        public string About()
        {
            return "Tên sinh viên: Nguyễn Văn A";
        }

        public string Contact()
        {
            return "Email: nguyenvana@example.com";
        }
    }
}