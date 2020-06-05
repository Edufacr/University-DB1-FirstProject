SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 04/06/2020
-- Description:	Gets all users that can acces a property
-- =============================================
CREATE PROCEDURE SP_getPropertyUsers
	-- Add the parameters for the stored procedure here
    @pPropertyNumber int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
        SELECT  Username from activePropertiesUsersRelations where PropertyNumber = @pPropertyNumber;
		return @@ROWCOUNT;
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO