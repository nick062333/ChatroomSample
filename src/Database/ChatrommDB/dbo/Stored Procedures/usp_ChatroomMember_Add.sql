-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/16
-- Description:	 新增聊天室成員
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_ChatroomMember_Add]
    @ChatroomId uniqueidentifier,
    @UserId bigint,
    @EntryTime datetime
AS
BEGIN
    INSERT INTO [dbo].[ChatroomMember]
               ([ChatroomId],
			   [UserId],
			   [EntryTime])
         VALUES
               (@ChatroomId,
			   @UserId,
			   @EntryTime)
END;