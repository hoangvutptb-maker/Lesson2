using Microsoft.AspNetCore.Mvc;
using Lesson2.Models;

namespace Lesson2.Controllers
{
    public class BookController : Controller
    {
        // Khởi tạo danh sách sách giả lập ban đầu
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Name = "Clean Code", Price = 20 },
            new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 },
            new Book { Id = 3, Name = "Design Pattern", Price = 25 }
        };

        // Chức năng 1: Danh sách sách
        public IActionResult Index()
        {
            return View(books);
        }

        // Chức năng 2: Chi tiết sách theo Id
        public IActionResult Detail(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound("Không tìm thấy cuốn sách này!");
            }
            return View(book);
        }

        // Chức năng 3 (GET): Hiển thị Form thêm sách
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Chức năng 3 & Bài 6 (POST): Xử lý thêm sách kèm bắt lỗi ModelState
        [HttpPost]
        public IActionResult Create(Book newBook)
        {
            // Kiểm tra xem dữ liệu gửi lên có thỏa mãn các điều kiện ở Model không
            if (ModelState.IsValid)
            {
                // Tự động tăng Id lên 1
                newBook.Id = books.Max(b => b.Id) + 1;
                books.Add(newBook);

                // Gửi thông báo thành công ra giao diện
                ViewBag.SuccessMessage = "Thêm sách thành công!";
                return View();
            }

            // Nếu có lỗi (Ví dụ: tên trống hoặc giá <= 0), trả lại giao diện kèm thông báo lỗi
            return View(newBook);
        }
    }
}