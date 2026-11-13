using System.ComponentModel.DataAnnotations;

namespace SIMS.DTOs
{
    // DTO nhận dữ liệu gửi lên khi đăng nhập
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "Username không được để trống")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password không được để trống")]
        public string Password { get; set; } = string.Empty;
    }
}

