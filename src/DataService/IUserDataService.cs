using DataClass.DTOs;
using DataClass.Models;

namespace DataService
{
    public interface IUserDataService
    {
        Task<UserModel> GetUserAsync(string account);
        
        Task AddUserAsync(RegisterRequest registerRequest); 
    }
}