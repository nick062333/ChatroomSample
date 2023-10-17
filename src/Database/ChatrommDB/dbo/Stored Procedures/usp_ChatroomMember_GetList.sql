-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/17 
-- Description:	 取得聊天室群組
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_ChatroomMember_GetList]
    --@UesrId bigint
AS
BEGIN
	SELECT ChatroomId, ChatroomType, UserId, EntryTime 
	FROM Chatroom
	INNER JOIN ChatroomMember ON Chatroom.Id = ChatroomMember.ChatroomId
END;