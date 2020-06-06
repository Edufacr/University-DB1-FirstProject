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
-- Description:	Updates an element of the table DB1P_Owners.
-- =============================================
create PROCEDURE SP_updateOwner 
	
	@pDocValue VARCHAR(30), 
	@pNewName varchar(50),
	@pNewDocValue VARCHAR(30),
	@pNewDocType_Id int

AS
BEGIN
	begin try
		update dbo.DB1P_Owners
		set Name = @pNewName,
			DocValue = @pNewDocValue,
			DocType_Id = @pNewDocType_Id
		where DocValue = @pDocValue
		return 1
	end try
	begin catch
		return @@Error * -1
	end catch	


END
GO
