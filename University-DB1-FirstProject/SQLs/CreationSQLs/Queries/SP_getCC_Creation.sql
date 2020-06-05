SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 04/06/2020
-- Description:	gets all CC
-- =============================================
CREATE PROCEDURE SP_getCC
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
BEGIN TRY
    SELECT * FROM DB1P_ChargeConcepts;
	return SCOPE_IDENTITY();
END TRY
BEGIN CATCH
	return @@Error * -1
END CATCH
END
GO