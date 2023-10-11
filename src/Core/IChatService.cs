
using DataClass.DTOs;

namespace Core
{
    public interface IChatService
    {
        // /// <summary>
        // /// 取得群組內的訊息列表
        // /// </summary>
        // /// <param name="groupName">群組名稱</param>
        // /// <returns></returns>
        // public Task<List<ChatMessageResponse>> GetChatMessageList(string groupName);

        /// <summary>
        /// 取得訊息紀錄
        /// </summary>
        /// <param name="getMessageLogListRequest"></param>
        /// <returns></returns>
        public Task<GetMessageLogListResponse> GetMessageLogListAsync(GetMessageLogListRequest getMessageLogListRequest);

        /// <summary>
        /// 接收訊息後的處理程序
        /// </summary>
        /// <param name="receiveMessageProcessRequest"></param>
        /// <returns></returns>
        public Task ReceiveMessageProcessAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest);
    }
}
