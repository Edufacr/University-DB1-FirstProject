SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 03/06/2020
-- Description:	insert in ConsumptionCC
-- =============================================
CREATE PROCEDURE SP_insertConsumptionCC
	-- Add the parameters for the stored procedure here
    @pId int, @pConsumptionM3 int --preguntar si hay que cambiarlo a money
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO DB1P_Consumption_CC (Id, ConsumptionM3)
        VALUES (@pId,@pConsumptionM3);
        return SCOPE_IDENTITY()
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO