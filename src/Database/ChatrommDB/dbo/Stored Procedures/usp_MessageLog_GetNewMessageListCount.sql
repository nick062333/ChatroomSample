-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/13 
-- Description:	 取得查詢範圍內前面訊息筆數
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_MessageLog_GetNewMessageListCount]
    @GroupId uniqueidentifier,
    @StartId int
AS
BEGIN
	SELECT COUNT(msgs.[Id])
	FROM [dbo].[MessageLog] AS msgs
	WHERE msgs.[GroupId] = @GroupId AND msgs.[Id] > @StartId;
END;