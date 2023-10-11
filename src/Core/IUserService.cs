using DataClass.DTOs;

namespace Core
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterRequest registerRequest);

        Task<ValidateUserResponse> ValidateUserAsync(ValidateUserRequest validateUserRequest);
    }
}