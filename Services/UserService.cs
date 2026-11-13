using SIMS.Interfaces;
using SIMS.SimsDB.Entities;

namespace SIMS.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        // khởi tạo constructor 
        public UserService (IUserRepository repository)
        {
            _repo = repository;
        }




        // nghiệp vụ check mật khẩu 

        public async Task<User?> LoginUserAsync(string username, string password)
        {
            var user = await _repo.GetuserByUsername(username);
            if (user == null )
            {
                return null;
            }

            // xử lý giải mã mk sẽ làm sau 
            return user.Password.Equals(password) ? user : null;
        }
    }
}
