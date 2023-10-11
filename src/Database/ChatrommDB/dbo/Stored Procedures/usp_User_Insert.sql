-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/11 
-- Description:	 新增使用者
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_User_Insert]
    @ChatroomId uniqueidentifier,
    @SendUserId bigint,
    @Message VARCHAR(max),
    @SendTime datetime
AS
BEGIN
    INSERT INTO [dbo].[Message]
               ([ChatroomId]
               ,[SendUserId]
               ,[Status]
               ,[Message]
               ,[SendTime])
         VALUES
               (@ChatroomId
               ,@SendUserId
               ,1
               ,@Message
               ,@SendTime)
END;