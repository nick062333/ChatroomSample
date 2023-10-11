using Adapter.Models;

namespace Adapter.Interfaces
{
    public interface IUserAdapter
    {
        Task<User> GetUserAsync(string account);

        public Task InsertUserAsync(User user);
    }
}
