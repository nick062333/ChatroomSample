-- ============================================= 
-- Author:		 Nick Huang 
-- Create date: 2023/10/17 
-- Description:	 取得所有使用者
-- ============================================= 

CREATE PROCEDURE [dbo].[usp_User_GetList]
AS
BEGIN
	SELECT Id, Account, [Password], UserName, CreateTime, LastLoginTime
	FROM [dbo].[User] AS users
END;