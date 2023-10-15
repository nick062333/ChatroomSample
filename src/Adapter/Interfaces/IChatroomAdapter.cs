using Adapter.DBModel;
using Adapter.Models;

namespace Adapter.Interfaces
{
    public interface IChatroomAdapter
    {
        /// <summary>
        /// 取得聊天室
        /// </summary>
        /// <returns>聊天室資訊</returns>
        Task<IEnumerable<ChatroomMember>> GetChatroomListAsnyc();

        /// <summary>
        /// 建立聊天室
        /// </summary>
        /// <param name="userIds">聊天對象-使用者代碼</param>
        /// <returns>聊天室資訊</returns>
        Task<Chatroom> AddChatroomAsync(params long[] userIds);
    }
}