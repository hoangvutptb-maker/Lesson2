using System.ComponentModel.DataAnnotations;

namespace Lesson2.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Không được để trống tên sách")]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        public double Price { get; set; }
    }
}