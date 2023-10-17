-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/11 
-- Description:	 新增使用者
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_User_Insert]
    @Account varchar(20),
    @Password char(64),
    @UserName nvarchar(20),
    @CreateTime datetime
AS
BEGIN
	INSERT INTO [dbo].[User]
           ([Account]
		   ,[Password]
           ,[UserName]
           ,[CreateTime])
     VALUES
           (@Account
           ,@Password
           ,@UserName
           ,@CreateTime)
END;