CREATE TABLE [dbo].[Chatroom] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [ChatroomType] TINYINT          NOT NULL,
    [CreateTime]   DATETIME         CONSTRAINT [DF_Chatroom_CreateTime] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Chatroom] PRIMARY KEY CLUSTERED ([Id] ASC)
);

