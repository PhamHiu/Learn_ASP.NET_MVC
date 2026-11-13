using SIMS.SimsDB.Entities;
namespace SIMS.Interfaces
{
    public interface IUserRepository
    {
        // khởi tạo interface của user 
        Task<User?> GetuserByUsername(string Username);
        Task<User?> GetUserById(int id);
    }
}
