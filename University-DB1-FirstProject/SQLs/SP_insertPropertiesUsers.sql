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
    @pPropertyId int,@pUserId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
        INSERT INTO DB1P_PropertiesUsers
        VALUES(@pPropertyId,@pUserId,1);
		return SCOPE_IDENTITY();
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO