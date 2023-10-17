-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/13 
-- Description:	 查詢群組中的訊息總筆數
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_MessageLog_GroupTotalCount_Get]
    @GroupId uniqueidentifier
AS
BEGIN
	SELECT COUNT(msgs.GroupId)
	FROM [dbo].[MessageLog] AS msgs
	INNER JOIN [dbo].[User] AS users ON users.Id = msgs.SendUserId
	WHERE [GroupId] =  @GroupId 
END;