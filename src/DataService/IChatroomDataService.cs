using Adapter.DBModel;
using DataClass.Models;

namespace DataService
{
    public interface IChatroomDataService
    {
        /// <summary>
        /// 取得使用者所有聊天室
        /// </summary>
        /// <returns>聊天室資訊</returns>
        Task<List<ChatroomModel>> GetChatroomListAsnyc();

        /// <summary>
        /// 建立聊天室
        /// </summary>
        /// <param name="userIds">聊天對象-使用者代碼</param>
        /// <returns>聊天室資訊</returns>
        Task<Chatroom> AddChatroomAsync(params long[] userIds);
    }
}