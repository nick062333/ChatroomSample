using Adapter.DBModel;
using DataClass.Models;

namespace Core
{
    public interface IChatroomService
    {
        /// <summary>
        /// 取得使用者聊天室列表
        /// </summary>
        /// <param name="userId">使用者代碼</param>
        /// <returns></returns>
        Task<List<ChatroomModel>> GetChatroomListAsnyc(long userId);

        /// <summary>
        /// 建立聊天室
        /// </summary>
        /// <param name="userIds">聊天對象-使用者代碼</param>
        /// <returns>聊天室資訊</returns>
        Task<Chatroom> AddChatroomAsync(params long[] userIds);
    }
}
