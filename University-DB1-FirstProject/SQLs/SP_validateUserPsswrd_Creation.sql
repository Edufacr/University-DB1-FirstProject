SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 03/06/2020
-- Description:	validates is password and username entered match (returns 1 if true)
-- =============================================
CREATE PROCEDURE SP_validateUserPsswrd
	-- Add the parameters for the stored procedure here
    @Username VARCHAR(50),@Password VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
		DECLARE @passwordPointer VARCHAR(50);
		SELECT @passwordPointer from DB1P_Users where @Username = Username 
		IF @passwordPointer = @Password 
			BEGIN
				RETURN 1
			END
		ELSE
			BEGIN
				RETURN -5000 --Error: Contrasena no coincide
			END
		return SCOPE_IDENTITY();
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO