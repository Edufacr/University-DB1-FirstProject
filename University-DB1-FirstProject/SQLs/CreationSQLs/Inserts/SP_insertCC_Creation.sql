SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 03/06/2020
-- Description:	Inserts into ChargeConcepts
-- =============================================
CREATE PROCEDURE SP_insertCC_Creation
	-- Add the parameters for the stored procedure here
    @pId int, @pName VARCHAR(50),@pMoratoryInterestRate REAL, @pReciptEmisionDay TINYINT,@pExpirationDays TINYINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
        INSERT INTO DB1P_ChargeConcepts (Id,Name, MoratoryInterestRate,ReciptEmisionDay,ExpirationDays)
        VALUES (@pId,@pName,@pMoratoryInterestRate,@pReciptEmisionDay,@pExpirationDays);
	COMMIT
	return SCOPE_IDENTITY()
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO