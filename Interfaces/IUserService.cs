using SIMS.SimsDB.Entities;

namespace SIMS.Interfaces
{
    public interface IUserService
    {
        Task<User?> LoginUserAsync(string username, string password );
    }
}
