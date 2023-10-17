CREATE TABLE [dbo].[User] (
    [Id]            BIGINT        IDENTITY (1, 1) NOT NULL,
    [Account]       VARCHAR (20)  NOT NULL,
    [Password]      CHAR (64)     NOT NULL,
    [UserName]      NVARCHAR (20) NOT NULL,
    [CreateTime]    DATETIME      NOT NULL,
    [LastLoginTime] DATETIME      NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);





