SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 03/06/2020
-- Description:	insert in FixedCC
-- =============================================
CREATE PROCEDURE SP_insertFixedCC
	-- Add the parameters for the stored procedure here
    @pId int,@pAmount money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO DB1P_Fixed_CC (Id,Amount)
        VALUES (@pId,@pAmount);
	COMMIT
	return SCOPE_IDENTITY()
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO