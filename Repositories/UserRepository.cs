
using Microsoft.EntityFrameworkCore;
using SIMS.Interfaces;
using SIMS.SimsDB;
using SIMS.SimsDB.Entities;

namespace SIMS.Repositories
{
    public class UserRepository : IUserRepository
    {
        // nơi truy vấn dữ liệu  viết code truy vấn dữ liệu từ db măc định sẽ có sẵn crud 
        // impliment interface IUserepository

        private readonly SimsDbContext _dbContext; // _ đọc là private 


        // khởi tạo đối tượng Constructor 
        public UserRepository (SimsDbContext context)
        {
            _dbContext = context; 
        }





        public async Task<User?> GetUserById(int id) // xử lý đồng bộ  -- nghĩa là phải trả về thì mới thực hiện task tiếp , 
        {


            return await _dbContext.Users.FindAsync(id).AsTask();
        }




      
        public async Task<User?> GetuserByUsername(string Username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == Username);

        }

    }
}
