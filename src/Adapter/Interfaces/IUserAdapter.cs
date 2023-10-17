using Adapter.Models;

namespace Adapter.Interfaces
{
    public interface IUserAdapter
    {
        Task<User> GetUserAsync(string account);

        Task InsertUserAsync(User user);

        Task<IEnumerable<User>> GetUserAsync();
    }
}
