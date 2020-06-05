SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 06/06/2020
-- Description:	get password of specify user
-- =============================================
CREATE PROCEDURE SP_getUserPassword
	-- Add the parameters for the stored procedure here
    @pUsername VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
        SELECT Password from DB1P_Users where Username = @pUsername;
		return SCOPE_IDENTITY();
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO