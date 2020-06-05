SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 04/06/2020
-- Description:	Gets all properties seen by a user
-- =============================================
CREATE PROCEDURE SP_getUsersProperties_Creation
	-- Add the parameters for the stored procedure here
    @pUsername VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
        SELECT PropertyName,PropertyAddress,PropertyNumber,PropertyValue from activePropertiesUsersRelations
        where Username = @pUsername;
		return @@ROWCOUNT;
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO