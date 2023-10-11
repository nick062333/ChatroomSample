using Adapter;
using Adapter.Interfaces;
using Adapter.Models;
using AutoMapper;
using DataClass.DTOs;
using DataClass.Models;

namespace DataService.Service
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserAdapter _userAdapter;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserDataService(IUserAdapter userAdapter, IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _mapper = mapper;
            _userAdapter = userAdapter;
            _unitOfWork = unitOfWork;
        }

        public async Task AddUserAsync(RegisterRequest registerRequest)
        {
            _unitOfWork.BeginTransaction();
            var user = MapToUser(registerRequest);
            user.SetPassword(registerRequest.Password);
            await _userAdapter.InsertUserAsync(user);
            _unitOfWork.Commit();
        }

        private static User MapToUser(RegisterRequest registerRequest)
                => new(registerRequest.UserName, registerRequest.Account, DateTime.Now);

        public async Task<UserModel> GetUserAsync(string account)
        {
            var user = await _userAdapter.GetUserAsync(account);
            return _mapper.Map<UserModel>(user);
        }
    }
}