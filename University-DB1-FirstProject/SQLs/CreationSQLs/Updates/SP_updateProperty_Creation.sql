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
-- Create date: 2020/5/30
-- Description:	Updates an element of the table DB1P_Properties.
-- =============================================
CREATE PROCEDURE SP_updateProperty 
	@pPropertyNumber int, 
	@pNewName varchar(50), 
	@pNewValue money, 
	@pNewAddress varchar(100),
	@pNewPropertyNumber int
AS
BEGIN
	begin try
		update dbo.DB1P_Properties
		set Name = @pNewName, 
			Value = @pNewValue,
			Address = @pNewAddress,
			PropertyNumber = @pNewPropertyNumber
		where PropertyNumber = @pPropertyNumber
		return 1
	end try
	begin catch
		return @@Error * -1
	end catch	
END
GO
