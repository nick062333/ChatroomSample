
using DataClass.DTOs;

namespace Core
{
    public interface IChatService
    {
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
