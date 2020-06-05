SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 04/06/2020
-- Description:	logically deletes a properties user relation
-- =============================================
CREATE PROCEDURE SP_deletePropertiesUsers
	-- Add the parameters for the stored procedure here
    @pPropertyId int, @pUserId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
        UPDATE DB1P_PropertiesUsers
        set
        Active = 0
		where User_Id = @pUserId and Property_Id = @pUserId; 
		return SCOPE_IDENTITY();
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO