using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Lesson2.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Chức năng 1: Ghi log thông tin Request đầu vào (Thời gian, Method, Path)
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var method = context.Request.Method;
            var path = context.Request.Path.ToString();

            Console.WriteLine($"[{time}] Method: {method} - Path: {path}");

            // Chức năng 3: Chặn truy cập URL không hợp lệ mức cơ bản (ID <= 0)
            // Nếu người dùng truy cập /Book/Detail/0 hoặc /Book/Detail/-1
            if (path.Equals("/Book/Detail/0", StringComparison.OrdinalIgnoreCase) ||
                path.Equals("/Book/Detail/-1", StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = 400; // Đặt mã trạng thái 400 Bad Request
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync("Book id không hợp lệ");

                // Ngắt luồng pipeline tại đây, không cho request đi tiếp vào Controller
                return;
            }

            // Chuyển tiếp request sang Middleware tiếp theo hoặc vào Controller xử lý
            await _next(context);

            // Chức năng 2: Ghi log status code sau khi hệ thống xử lý xong request
            Console.WriteLine($"Status Code: {context.Response.StatusCode}");
        }
    }
}