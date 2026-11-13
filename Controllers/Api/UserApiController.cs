using Microsoft.AspNetCore.Mvc;
using SIMS.DTOs;
using SIMS.Interfaces;

namespace SIMS.Controllers.Api
{
    [ApiController]
    [Route("api/users")]
    public class UserApiController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserApiController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/users/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = $"Không tìm thấy người dùng có Id = {id}"
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
                data = response
            });
        }

        // GET: api/users/by-username/{username}
        [HttpGet("by-username/{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _userRepository.GetuserByUsername(username);
            if (user == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = $"Không tìm thấy người dùng có Username: {username}"
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
                data = response
            });
        }
    }
}

