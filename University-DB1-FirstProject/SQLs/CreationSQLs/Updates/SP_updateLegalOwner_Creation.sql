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
-- Create date: 2020/5/31
-- Description:	Updates a [DB1P_LegalOwners] element.
-- =============================================
CREATE PROCEDURE SP_updateLegalOwner
	
	@pNewResponsibleName varchar(50), 
	@pNewResp_DocId_type int, 
	@pNewResp_DocValue VARCHAR(30), 
	@pLegalOwner_DocValue VARCHAR(30)

AS 
BEGIN
	
	declare @Id int

	begin try
		
		select @Id = o.Id
		from activeOwners as o
		where o.DocValue = @pLegalOwner_DocValue and o.DocType_Id = 4

		update dbo.DB1P_LegalOwners
		set ResponsibleName = @pNewResponsibleName,
			Resp_DocType_Id = @pNewResp_DocId_type,
			Resp_DocValue = @pNewResp_DocValue
		where Id = @Id
	
		return 1
	
	end try
	
	begin catch
	
		return @@Error * -1
	
	end catch

END
GO
