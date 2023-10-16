using DataClass.DTOs;
using DataClass.Enums;

namespace Core
{
    public interface IMessageService
    {
        /// <summary>
        /// 取得訊息紀錄列表總筆數
        /// </summary>
        /// <param name="getMessageLogTotalCountRequest">查詢參數</param>
        /// <returns></returns>
        public Task<GetMessageLogTotalCountResponse> GetMessageLogTotalCountAsync(GetMessageLogTotalCountRequest getMessageLogTotalCountRequest);

        /// <summary>
        /// 取得訊息紀錄
        /// </summary>
        /// <param name="getMessageLogListRequest">查詢參數</param>
        /// <returns></returns>
        public Task<GetMessageLogListResponse> GetMessageLogListAsync(GetMessageLogListRequest getMessageLogListRequest);

        /// <summary>
        /// 接收訊息後的處理程序
        /// </summary>
        /// <param name="receiveMessageProcessRequest">查詢參數</param>
        /// <returns></returns>
        public Task ReceiveMessageProcessAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest);

        /// <summary>
        /// 取得Id範圍內的訊息
        /// </summary>
        /// <param name="request">查詢參數</param>
        /// <returns></returns>
        public Task<GetMessageLogListByIdRangeResponse> GetMessageLogListByIdRangeAsync(GetMessageLogListByIdRangeRequest request);
    }
}