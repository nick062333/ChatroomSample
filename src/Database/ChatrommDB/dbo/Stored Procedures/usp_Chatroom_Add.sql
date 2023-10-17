-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/16
-- Description:	 新增聊天室
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_Chatroom_Add]
    @Id uniqueidentifier,
    @ChatroomType tinyint,
    @CreateTime datetime
AS
BEGIN
    INSERT INTO [dbo].[Chatroom]
               ([Id],
			   [ChatroomType],
			   [CreateTime])
         VALUES
               (@Id,
			   @ChatroomType,
			   @CreateTime)
END;