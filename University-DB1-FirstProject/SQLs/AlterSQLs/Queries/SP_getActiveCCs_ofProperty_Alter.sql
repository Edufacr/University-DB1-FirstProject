USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_getActiveCCs_ofProperty]    Script Date: 6/1/2020 12:58:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/6/1
-- Description:	Query all active charge concepts on a single property.
-- =============================================
ALTER PROCEDURE [dbo].[SP_getActiveCCs_ofProperty]
	@pPropertyNumber int
AS
BEGIN

	declare @PropertyId int

	begin try
		
		select @PropertyId = p.Id
		from activeProperties as p
		where p.PropertyNumber = @pPropertyNumber


		select cc.CCName, cc.ExpirationDays, cc.MoratoryInterestRate, cc.ReciptEmisionDay, cc.BeginDate, cc.EndDate
		from completeCC_onProperties as cc
		where Property_Id = @PropertyId
		return 1
	end try

	begin catch
		return @@Error * -1
	end catch

END
