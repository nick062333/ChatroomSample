CREATE PROCEDURE [dbo].[InsertMessage]
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