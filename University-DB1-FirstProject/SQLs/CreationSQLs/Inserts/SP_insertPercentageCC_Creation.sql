SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 03/06/2020
-- Description:	insert in PercentageCC
-- =============================================
CREATE PROCEDURE SP_insertPercentageCC
	-- Add the parameters for the stored procedure here
    @pId int, @pPercentage REAL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO DB1P_Percentage_CC (Id, PercentageValue)
        VALUES (@pId,@pPercentage);
	COMMIT
	return SCOPE_IDENTITY()
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO