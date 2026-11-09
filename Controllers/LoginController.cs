using Microsoft.AspNetCore.Mvc;
using SIMS.Models; // import model 

namespace SIMS.Controllers
{
    public class LoginController : Controller


    {
        // khi muốn trả về 1 giao diện nên dùng hàm  public IActionResult Index() để làm trang đầu tiên vì mặc định trình duyệt sẽ chạy vào index khi 
        [HttpGet]
        public IActionResult Index()
        {
            return View();// hiển thị 1 giao diện nào đó rồi truyền va
        }
        [HttpPost]


        // bước 2 : import model và khởi tạo hàm nạp chồng của login  
        public IActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                // Xử lý logic đăng nhập ở đây
                string username = model.Username.ToString().Trim();
                string password = model.Password.ToString().Trim();
                if (username == "admin" && password == "123")
                {
                    // Đăng nhập thành công, chuyển hướng đến trang chính
                    return RedirectToAction(     "Index",       "Dashboard"); 
                    // truyền vào            <Method>, <tên controller>
                }

                // Đăng nhập thất bại, hiển thị thông báo lỗi
                ViewData["ErrorMessage"] = "Tên đăng nhập hoặc mật khẩu không đúng.";
                //ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng.");
                

            }
            return View(model);
        }
    }
    
}
