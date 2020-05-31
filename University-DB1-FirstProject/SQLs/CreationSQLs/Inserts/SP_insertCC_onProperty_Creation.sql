-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/30
-- Description:	Insert an element on DB1P_CC_onProperties.
-- =============================================
create procedure SP_insertCC_onPropety
	@pPropertyId int, 
	@pChargeConceptId int, 
	@pBeginDate date

AS
BEGIN
	
	begin try
		insert into dbo.DB1P_CC_onProperties (Property_Id, ChargeConcept_Id, BeginDate, EndDate, Active)
		values (@pPropertyId, @pChargeConceptId, @pBeginDate, null, 1)
		return 1
	end try
	begin catch
		return @@Error * -1
	end catch
		
END
GO
