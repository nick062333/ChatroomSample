-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/16 
-- Description:	 透過Id查詢歷史訊息紀錄
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_MessageLog_GetHistoryList]
    @GroupId uniqueidentifier,
    @EndMessageId bigint,
	@PageNumber int,
	@PageSize int
AS
BEGIN
	SELECT msgs.[Id]
		  ,msgs.[GroupId]
		  ,msgs.[Status]
		  ,msgs.[Message]
		  ,msgs.[SendUserId]
		  ,msgs.[SendTime]
		  ,users.UserName
	FROM [dbo].[MessageLog] AS msgs
	LEFT JOIN [dbo].[User] AS users ON msgs.SendUserId = users.Id
	WHERE msgs.[Id] < @EndMessageId AND msgs.GroupId = @GroupId
	ORDER BY msgs.[Id] DESC
	OFFSET (@PageNumber - 1) * (@PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;
END;