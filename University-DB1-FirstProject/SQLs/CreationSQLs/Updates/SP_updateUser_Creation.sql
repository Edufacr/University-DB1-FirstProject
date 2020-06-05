SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 02/06/2020
-- Description:	updates User values with username
-- =============================================
CREATE PROCEDURE SP_updateUser
	-- Add the parameters for the stored procedure here
	@pUsername varchar(50),@pNewUserName varchar(50),@pNewPassword varchar(50),@pNewUserType bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
        UPDATE DB1P_Users
        set
        Username = @pNewUserName,
		Password = @pNewPassword,
		UserType = @pNewUserType
		from DB1P_Users
		where Username = @pUsername;
	COMMIT
	return SCOPE_IDENTITY();
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO