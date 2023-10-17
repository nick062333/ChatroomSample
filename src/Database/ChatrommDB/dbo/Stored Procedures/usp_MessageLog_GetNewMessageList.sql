-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/13 
-- Description:	 透過Id查詢訊息紀錄
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_MessageLog_GetNewMessageList]
    @GroupId uniqueidentifier,
    @StartId bigint,
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
	WHERE msgs.[GroupId] = @GroupId AND msgs.[Id] > @StartId
	ORDER BY msgs.[Id] DESC 
	OFFSET (@PageNumber - 1) * (@PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;
END;