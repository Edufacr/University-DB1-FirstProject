USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_getOwnersOfProperty]    Script Date: 6/1/2020 1:19:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/6/1
-- Description:	Query the owners of a property.
-- =============================================
ALTER PROCEDURE [dbo].[SP_getOwnersOfProperty]
	@pPropertyNumber int
AS
BEGIN

	declare @PropertyId int

	begin try
		
		select @PropertyId = p.Id
		from activeProperties as p
		where p.PropertyNumber = @pPropertyNumber

		select r.ownerName as Name, r.ownerDocValue as DocValue, r.ownerDocType as DocType 
		from activePropertiesOwnersRelations as r
		where r.PropertyId = @PropertyId

		return 1

	end try

	begin catch
		
		return @@Error * -1

	end catch
END
