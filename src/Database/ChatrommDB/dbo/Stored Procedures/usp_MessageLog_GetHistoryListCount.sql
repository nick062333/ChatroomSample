-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/16 
-- Description:	 取得歷史訊息筆數
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_MessageLog_GetHistoryListCount]
    @GroupId uniqueidentifier,
    @EndMessageId int
AS
BEGIN
	SELECT COUNT(msgs.[Id])
	FROM [dbo].[MessageLog] AS msgs
	WHERE msgs.[GroupId] = @GroupId AND msgs.[Id] < @EndMessageId
END;