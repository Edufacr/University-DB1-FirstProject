SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 04/06/2020
-- Description:	get the percentage of a PercentageCC
-- =============================================
CREATE PROCEDURE SP_getPercentageCCPercent
	-- Add the parameters for the stored procedure here
    @pId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
    SELECT PercentageValue from DB1P_Percentage_CC where Id = @pId;
	return SCOPE_IDENTITY()
END TRY
BEGIN CATCH
	return @@Error * -1
END CATCH
END
GO