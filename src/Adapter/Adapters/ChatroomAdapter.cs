using System.Data;
using Adapter.DBModel;
using Adapter.Interfaces;
using Adapter.Models;
using Dapper;
using Utility;

namespace Adapter.Adapters
{
    public class ChatroomAdapter : IChatroomAdapter
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChatroomAdapter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddChatroomAsync(Chatroom chatroom)
        {
            var param = new DynamicParameters();
            param.Add("@Id", chatroom.Id, DbType.Guid);
            param.Add("@ChatroomType", chatroom.ChatroomType, dbType: DbType.Int64);
            param.Add("@CreateTime", TwDateTime.Now, dbType: DbType.DateTime);

            await _unitOfWork.Connection.ExecuteAsync("usp_Chatroom_Add",param, _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ChatroomMember>> GetChatroomListAsnyc()
        {
            return await _unitOfWork.Connection.QueryAsync<ChatroomMember>("usp_ChatroomMember_GetList", commandType: CommandType.StoredProcedure);
        }
    }
}