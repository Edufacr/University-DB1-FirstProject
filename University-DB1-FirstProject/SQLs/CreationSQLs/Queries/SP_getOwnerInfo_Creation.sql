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
-- Create date: 2020/6/1
-- Description:	Query an owner's info by DocValue and DocType_Id
-- =============================================
CREATE PROCEDURE SP_getOwnerInfoByDocValue
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
			begin
				select * 
				from dbo.completeLegalOwners
				where Id = @Id
			end
		else
			begin
				select *
				from dbo.activeOwners
				where Id = @Id
			end

		return 1

	end try

	begin catch

		return @@Error * -1

	end catch

END
GO
