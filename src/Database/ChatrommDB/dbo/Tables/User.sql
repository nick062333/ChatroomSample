CREATE TABLE [dbo].[User] (
    [Id]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [Account]    VARCHAR (20)  NOT NULL,
    [UserName]   NVARCHAR (20) NOT NULL,
    [CreateTime] DATETIME      NOT NULL,
    [Password]   CHAR (32)     NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

