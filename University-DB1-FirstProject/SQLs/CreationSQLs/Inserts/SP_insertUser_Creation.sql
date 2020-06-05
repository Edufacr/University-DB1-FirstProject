SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 03/06/2020
-- Description:	Inserts a user
-- =============================================
CREATE PROCEDURE SP_insertUser
	-- Add the parameters for the stored procedure here
    @pUserName VARCHAR(50),@pPassword VARCHAR(50),@pAdminType bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
        INSERT INTO DB1P_Users (Username,Password, UserType,Active)
        VALUES (@pUserName,@pPassword,@pAdminType,1);
	COMMIT
	RETURN SCOPE_IDENTITY()
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO