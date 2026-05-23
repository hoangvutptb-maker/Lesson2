using Microsoft.AspNetCore.Mvc;

namespace Lesson2.Controllers
{
    public class ProductController : Controller
    {
        // Nhận tham số id (có thể null)
        public string Detail(int? id)
        {
            if (id == null)
            {
                return "Lỗi: Bạn chưa cung cấp ID sản phẩm!";
            }
            return "Product ID = " + id;
        }

        // Nhận tham số name
        public string Category(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "Lỗi: Bạn chưa cung cấp Tên danh mục!";
            }
            return "Category = " + name;
        }
    }
}