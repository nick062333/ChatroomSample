﻿CREATE TABLE [dbo].[MessageLog] (
    [Id]         BIGINT           IDENTITY (1, 1) NOT NULL,
    [GroupId]    UNIQUEIDENTIFIER NOT NULL,
    [Status]     TINYINT          CONSTRAINT [DF_Message_Status] DEFAULT ((0)) NOT NULL,
    [Message]    VARCHAR (MAX)    NOT NULL,
    [SendUserId] BIGINT           NOT NULL,
    [SendTime]   DATETIME         NOT NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([Id] DESC)
);




GO
CREATE NONCLUSTERED INDEX [IX_GroupId]
    ON [dbo].[MessageLog]([GroupId] ASC);

