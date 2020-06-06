SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 05/06/2020
-- Description:	Selects the extra value of the child tables
-- Returns 0 if Fixed, 1 if Percentage, 2 if Consumption
-- =============================================
CREATE PROCEDURE SP_getChildValue
	-- Add the parameters for the stored procedure here
	@pName VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
	DECLARE @CCid INT;
	SET @CCid = (SELECT Id from	 DB1P_ChargeConcepts where Name = @pName);
	IF EXISTS (Select Amount from DB1P_Fixed_CC where Id = @CCid )
		BEGIN
		Select Amount from DB1P_Fixed_CC where Id = @CCid 
		RETURN 0;
		END
 	IF EXISTS (Select PercentageValue from DB1P_Percentage_CC where Id = @CCid )
		BEGIN
		Select PercentageValue from DB1P_Percentage_CC where Id = @CCid
		RETURN 1;
		END
	IF EXISTS (Select ConsumptionM3 from DB1P_Consumption_CC where Id = @CCid )
		BEGIN
		Select ConsumptionM3 from DB1P_Consumption_CC where Id = @CCid
		RETURN 2;
		END
	IF EXISTS (Select Amount from DB1P_MoratoryInterest_CC where Id = @CCid )
		BEGIN
		Select Amount from DB1P_MoratoryInterest_CC where Id = @CCid 
		RETURN 3;
		END
END TRY
BEGIN CATCH
	return @@Error * -1
END CATCH
END
GO