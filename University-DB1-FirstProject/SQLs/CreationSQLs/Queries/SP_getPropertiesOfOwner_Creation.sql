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
-- Description:	Query the properties of an owner.
-- =============================================
CREATE PROCEDURE SP_getPropertiesOfOwner
	@pDocValue int,
	@pDocType_Id int
AS
BEGIN

	declare @OwnerId int

	begin try
		
		select @OwnerId = o.Id
		from activeOwners as o
		where o.DocValue = @pDocValue and o.DocType_Id = @pDocType_Id

		select * 
		from activePropertiesOwnersRelations as r
		where r.ownerId = @OwnerId

		return 1

	end try

	begin catch
		
		return @@Error * -1

	end catch
		
END
GO
