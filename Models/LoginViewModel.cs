using System.ComponentModel.DataAnnotations;

namespace SIMS.Models
{
    public class LoginViewModel
    {
        // bước 1: khởi tạo model cho login để thêm rule xác thực dữ liệu 
        // khai báo các thuộc tính cho form login
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string Password { get; set; }
    }
}
