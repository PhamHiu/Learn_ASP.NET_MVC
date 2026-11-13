using Microsoft.AspNetCore.Mvc;
using SIMS.Interfaces;
using SIMS.Models; // import model 

namespace SIMS.Controllers
{
    public class LoginController : Controller


    {
        private readonly IUserService _userService;

        //khởi tạo constructor
        public LoginController(IUserService userService)
        {
            _userService = userService; 
        }




        // khi muốn trả về 1 giao diện nên dùng hàm  public IActionResult Index() để làm trang đầu tiên vì mặc định trình duyệt sẽ chạy vào index khi 
        [HttpGet]
        public IActionResult Index()
        {
            return View();// hiển thị 1 giao diện nào đó rồi truyền va
        }
        [HttpPost]
        //lệnh dưới đây để check token csrf từ form gửi lên (luôn phải có nếu là form gửi lên )
        [ValidateAntiForgeryToken]















        // bước 2 : import model và khởi tạo hàm nạp chồng của login  
        public  async Task< IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                // Xử lý logic đăng nhập ở đây
                string username = model.Username.ToString().Trim();
                string password = model.Password.ToString().Trim();
                var user = await _userService.LoginUserAsync(username, password);

                if (user != null) // ở userservice đúng thì trả về user, sai thì trả về null => k null thì là đúng  
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














        //hàm logout và trả về giao diện login, sau này phairn thêm logic xóa cookei và section ... 

        [HttpPost]
        //checked token csrf gửi lên từ form 
        [ValidateAntiForgeryToken]

        public IActionResult Logout()
        {
            // thêm logic xóa các thông tin phiên ở đây
            return RedirectToAction("Index", "Login");
        }


    }
    
}
