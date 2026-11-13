using Microsoft.AspNetCore.Mvc;
using SIMS.DTOs;
using SIMS.Interfaces;

namespace SIMS.Controllers.Api
{
    [ApiController]
    [Route("api/auth")]
    public class AuthApiController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthApiController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Dữ liệu gửi lên không hợp lệ.",
                    errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            var user = await _userService.LoginUserAsync(request.Username, request.Password);
            if (user == null)
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "Tên đăng nhập hoặc mật khẩu không chính xác."
                });
            }

            var response = new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                Role = user.Role,
                Status = user.Status,
                CreatedAt = user.CreatedAt
            };

            return Ok(new
            {
                success = true,
                message = "Đăng nhập thành công!",
                data = response
            });
        }
    }
}

