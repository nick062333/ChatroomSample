-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/11 
-- Description:	 新增 Message Log 
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_MessageLog_Insert]
    @GroupId uniqueidentifier,
    @SendUserId bigint,
    @Message VARCHAR(max),
    @SendTime datetime
AS
BEGIN
    INSERT INTO [dbo].[MessageLog]
               ([GroupId]
               ,[SendUserId]
               ,[Status]
               ,[Message]
               ,[SendTime])
         VALUES
               (@GroupId
               ,@SendUserId
               ,1
               ,@Message
               ,@SendTime)

	SELECT SCOPE_IDENTITY() AS Id
END;