using Adapter.Interfaces;
using Adapter.Models;
using Dapper;
using System.Data;

namespace Adapter.Adapters
{
    public class UserAdapter : IUserAdapter
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserAdapter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUserAsync(string account)
        {
            var param = new DynamicParameters();
            param.Add("@Account", account, dbType: DbType.String);
            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<User>("usp_User_Get", param, commandType: CommandType.StoredProcedure);
        }

        public async Task InsertUserAsync(User user)
        {
            var param = new DynamicParameters();
            param.Add("@Account", user.Account, dbType: DbType.String);
            param.Add("@Password", user.Password, dbType: DbType.String);
            param.Add("@UserName", user.UserName, dbType: DbType.String);
            param.Add("@CreateTime", user.CreateTime , dbType: DbType.DateTime);

            await _unitOfWork.Connection.ExecuteAsync("usp_User_Insert", param, _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
        }
    }
}
