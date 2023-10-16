using System.Data;
using Adapter.Interfaces;
using Adapter.Models;
using Dapper;
using Utility;

namespace Adapter.Adapters
{
    public class ChatroomMemberAdapter : IChatroomMemberAdapter
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChatroomMemberAdapter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddChatroomMemberAsync(ChatroomMember chatroomMember)
        {
            var param = new DynamicParameters();
            param.Add("@ChatroomId", chatroomMember.ChatroomId, DbType.Guid);
            param.Add("@UserId", chatroomMember.UserId, dbType: DbType.Int64);
            param.Add("@EntryTime", TwDateTime.Now, dbType: DbType.DateTime);

            await _unitOfWork.Connection.ExecuteAsync("usp_ChatroomMember_Add",param, _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
        }
    }
}