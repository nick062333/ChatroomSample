-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/15 
-- Description:	 取得使用者的聊天室群組
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_ChatroomMember_GetListByUserId]
    @UesrId bigint
AS
BEGIN
	SELECT UserId, ChatroomId, EntryTime
	FROM ChatroomMember
	WHERE UserId = @UesrId
END;