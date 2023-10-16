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
        /// <param name="chatroomModel">聊天室資訊</param>
        /// <returns></returns>
        Task AddChatroomAsync(ChatroomModel chatroomModel);
    }
}