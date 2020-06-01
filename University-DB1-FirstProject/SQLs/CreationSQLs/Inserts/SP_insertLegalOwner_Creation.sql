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
-- Create date: 2020/5/27
-- Description:	Insert a Legal Owner to the table DB1P_LegalOwners
-- =============================================
CREATE PROCEDURE SP_insertLegalOwner
	
	@pName varchar(50), 
	@pResp_DocType_Id int, 
	@pResp_DocValue int, 
	@pLegalOwner_DocValue int

AS
BEGIN

	declare @Id int

	begin try
		
		select @Id = o.Id
		from activeOwners as o
		where o.DocValue = @pLegalOwner_DocValue and o.DocType_Id = 4

		insert into dbo.DB1P_LegalOwners (Id, ResponsibleName, Resp_DocType_Id, Resp_DocValue, Active)
		values (@Id, @pName, @pResp_DocType_Id, @pResp_DocValue, 1)
		return 1
	
	end try

	begin catch
	
		return @@Error * -1
	
	end catch
		
END
GO
