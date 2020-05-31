USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_insertCC_onPropety]    Script Date: 5/30/2020 5:52:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/30
-- Description:	Insert an element on DB1P_CC_onProperties.
-- =============================================
ALTER procedure [dbo].[SP_insertCC_onPropety]
	@pPropertyId int, 
	@pChargeConceptId int, 
	@pBeginDate date

AS
BEGIN
	
	begin try
		insert into dbo.DB1P_CC_onProperties (Property_Id, ChargeConcept_Id, BeginDate, EndDate, Active)
		values (@pPropertyId, @pChargeConceptId, @pBeginDate, null, 1)
	end try
	begin catch
		return @@Error * -1
	end catch
		
END
