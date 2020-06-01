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
-- Create date: 2020/6/1
-- Description:	Query the owners of a property.
-- =============================================
CREATE PROCEDURE SP_getOwnersOfProperty
	@pPropertyNumber int
AS
BEGIN

	declare @PropertyId int

	begin try
		
		select @PropertyId = p.Id
		from activeProperties as p
		where p.PropertyNumber = @pPropertyNumber

		select * 
		from activePropertiesOwnersRelations as r
		where r.PropertyId = @PropertyId

		return 1

	end try

	begin catch
		
		return @@Error * -1

	end catch
END
GO
