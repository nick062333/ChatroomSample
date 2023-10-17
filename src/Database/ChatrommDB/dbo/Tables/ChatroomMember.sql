CREATE TABLE [dbo].[ChatroomMember] (
    [UserId]     BIGINT           NOT NULL,
    [ChatroomId] UNIQUEIDENTIFIER NOT NULL,
    [EntryTime]  DATETIME         NOT NULL,
    CONSTRAINT [PK_ChatroomMember] PRIMARY KEY CLUSTERED ([UserId] ASC, [ChatroomId] ASC)
);

