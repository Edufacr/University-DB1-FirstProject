SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 04/06/2020
-- Description:	inserts a relation between Properties and Users
-- =============================================
CREATE PROCEDURE SP_insertPropertiesUsers
	-- Add the parameters for the stored procedure here
    @pPropertyNumber int,@pUsername VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
	DECLARE @PropertyId int;
	DECLARE @UserId int;
	BEGIN TRANSACTION
		SET @PropertyId = (Select Id from activeProperties where PropertyNumber = @pPropertyNumber)
		SET @UserId = (Select Id from activeUsers where Username = @pUsername)
        INSERT INTO DB1P_PropertiesUsers
        VALUES(@PropertyId,@UserId,1);
	COMMIT
	RETURN SCOPE_IDENTITY();
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO