-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/11 
-- Description:	 查詢使用者資訊
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_User_Get]
    @Account varchar(20)
AS
BEGIN
	SELECT Id, Account, [Password], UserName ,CreateTime
    FROM [dbo].[User]
	WHERE Account = @Account
END;