USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[sp_updateCC_onProperty]    Script Date: 5/30/2020 6:10:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/30
-- Description:	Update an element on DB1P_CC_onProperties.
-- =============================================
ALTER PROCEDURE [dbo].[sp_updateCC_onProperty]

	@pPropertyPropertyNumber int, 
	@pChargeConceptName varchar(50), 
	
	@pNewBeginDate date, 
	@pNewEndDate date

AS
BEGIN

	declare @ChargeConceptId int
	declare @PropertyId int

	begin try

		select @ChargeConceptId = Id
		from dbo.DB1P_ChargeConcepts
		where Name = @pChargeConceptName

		select @PropertyId = Id
		from dbo.DB1P_Properties
		where PropertyNumber = @pPropertyPropertyNumber

		update dbo.DB1P_CC_onProperties
		set BeginDate = @pNewBeginDate,
			EndDate = @pNewEndDate
		where Property_Id = @PropertyId and ChargeConcept_Id = @ChargeConceptId
	end try
	begin catch
		return @@Error * -1
	end catch	
END
