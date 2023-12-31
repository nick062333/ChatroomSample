using DataClass.Models;

namespace DataService
{
    public interface IChatroomDataService
    {
        /// <summary>
        /// 取得使用者聊天室資訊
        /// </summary>
        /// <param name="userId">傳送者</param>
        /// <param name="toUserId">接收者</param>
        /// <returns></returns>
        Task<ChatroomModel> GetChatroomAsync(long userId, long toUserId);


        /// <summary>
        /// 取得使用者的聊天室清單
        /// </summary>
        /// <param name="chatroomMembers">使用者代碼</param>
        /// <returns>聊天室資訊</returns>
        Task<List<ChatroomModel>> GetChatroomListAsync(long userId);

        /// <summary>
        /// 建立聊天室
        /// </summary>
        /// <param name="chatroom">聊天室資訊</param>
        /// <param name="chatroomMembers">聊天室成員</param>
        /// <returns></returns>
        Task AddChatroomAsync(ChatroomModel chatroom, List<ChatroomMemberModel> chatroomMembers);
    }
}