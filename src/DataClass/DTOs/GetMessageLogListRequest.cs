namespace DataClass.DTOs
{
    /// <summary>
    /// 取得訊息紀錄
    /// </summary>
    /// <param name="groupId">群組代碼</param>
    /// <param name="queryStartIndex">查詢起點</param>
    /// <param name="pageSize">每頁筆數</param>
    /// <returns></returns>
    public record GetMessageLogListRequest(
        Guid GroupId,
        int StartIndex, 
        int PageSize);
}