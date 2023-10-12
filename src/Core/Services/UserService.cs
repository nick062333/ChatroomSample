using DataClass.DTOs;
using DataClass.Enums;
using DataService;
using Utility;
using Utility.Cryptography;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDataService _userDataService;

        public UserService(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        public async Task RegisterAsync(RegisterRequest registerRequest)
        {
            await _userDataService.AddUserAsync(registerRequest);
        }

        public async Task<ValidateUserResponse> ValidateUserAsync(ValidateUserRequest validateUserRequest)
        {
            var userData = await _userDataService.GetUserAsync(validateUserRequest.account);

            if(userData != null && CheckPassword(validateUserRequest.password, userData.Password))
                return new ValidateUserResponse(userData.Id, userData.UserName);
            else
                throw new ChatroomException(ChatroomStatusCode.LoginFail);
        }

        private static bool CheckPassword(string password, string dbPasswordSha256)
        {
            var passwordSha256 = Sha256Helper.Encrypt(password);
            return passwordSha256 == dbPasswordSha256;
        }
    }
}