using DataClass.DTOs;
using DataClass.Enums;
using DataClass.Models;
using DataService;
using Utility;
using Utility.Authentication;
using Utility.Cryptography;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDataService _userDataService;
        private readonly JwtHelpers _jwtHelper;

        public UserService(IUserDataService userDataService, JwtHelpers jwtHelper)
        {
            _jwtHelper = jwtHelper;
            _userDataService = userDataService;
        }

        public async Task RegisterAsync(RegisterRequest registerRequest)
        {
            var userData = await _userDataService.GetUserAsync(registerRequest.Account);

            if(userData != null)
                throw new ChatroomException(ChatroomStatusCode.RegisterFail, "帳號已存在");

            await _userDataService.AddUserAsync(registerRequest);
        }

        public async Task<ValidateUserResponse> ValidateUserAsync(ValidateUserRequest validateUserRequest)
        {
            var userData = await _userDataService.GetUserAsync(validateUserRequest.account);

            if(userData != null && CheckUserData(validateUserRequest, userData))
            {
                var token = _jwtHelper.GenerateToken(userData.Id, userData.UserName);
                return new ValidateUserResponse(token, userData.Id, userData.UserName);
            }
            else
                throw new ChatroomException(ChatroomStatusCode.LoginFail);
        }

        private static bool CheckUserData(ValidateUserRequest validateUserRequest, UserModel userData)
        {
            var passwordSha256 = Sha256Helper.Encrypt(validateUserRequest.password);
            return userData.Password == passwordSha256 && userData.Account == validateUserRequest.account;
        }
    }
}