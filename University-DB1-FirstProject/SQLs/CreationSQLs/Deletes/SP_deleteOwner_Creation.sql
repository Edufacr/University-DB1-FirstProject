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
-- Author:		Jorge Guti�rrez Cordero
-- Create date: 2020/5/30
-- Description:	Delete  an element from DB1P_Owners.
-- =============================================
CREATE PROCEDURE SP_deleteOwner
	@pDocValue VARCHAR(30), 
	@pDocType_Id int
AS
BEGIN

	declare @Id int

	begin try

		select @Id = o.Id
		from activeOwners as o
		where DocValue = @pDocValue and DocType_Id = @pDocType_Id

		if @pDocType_Id = 4
		update dbo.DB1P_LegalOwners
		set Active = 0
		where Id = @Id

		update dbo.DB1P_Owners
		set Active = 0
		where Id = @Id
		return 1

	end try
	begin catch
		return @@Error * -1
	end catch
END
GO
