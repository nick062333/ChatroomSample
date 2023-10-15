using System.Data;
using Adapter.DBModel;
using Adapter.Interfaces;
using Adapter.Models;
using Dapper;

namespace Adapter.Adapters
{
    public class ChatroomAdapter : IChatroomAdapter
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChatroomAdapter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Chatroom> AddChatroomAsync(params long[] userIds)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ChatroomMember>> GetChatroomListAsnyc()
        {
            return await _unitOfWork.Connection.QueryAsync<ChatroomMember>("usp_ChatroomMember_GetList", commandType: CommandType.StoredProcedure);
        }
    }
}