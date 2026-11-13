using Microsoft.AspNetCore.Mvc;
using SIMS.Models;

namespace SIMS.Controllers.Web
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewData["age"] = "20";
            ViewData["name"] = "HiuHiu";
            // cách 2: lấy dữ liệu từ model lền view
            var Student = new StudentViewModel { studentId = 1, name = "HiuHiu", address = "HaNoi"};
            // phải truyền đối tượng vào thì bên kia mới nhận được nhé 
            return View(Student); 
        }
    }
}
