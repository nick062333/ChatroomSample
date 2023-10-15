using DataClass.DTOs;

namespace Core
{
    public interface IMessageService
    {
        /// <summary>
        /// 取得訊息紀錄列表總筆數
        /// </summary>
        /// <param name="getMessageLogTotalCountRequest"></param>
        /// <returns></returns>
        public Task<GetMessageLogTotalCountResponse> GetMessageLogTotalCountAsync(GetMessageLogTotalCountRequest getMessageLogTotalCountRequest);

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

        /// <summary>
        /// 取得Id範圍內的訊息
        /// </summary>
        /// <param name="groupId">群組代碼</param>
        /// <param name="startId">Id起始值</param>
        /// <returns></returns>
        public Task<GetMessageLogListByIdRangeRequest> GetMessageLogListByIdRangeAsync(Guid groupId, int startId);
    }
}