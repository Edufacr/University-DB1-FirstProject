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
-- Description:	Query all active charge concepts on properties.
-- =============================================
CREATE PROCEDURE SP_getActiveCC_onProperties

AS
BEGIN
	
	begin try
		select * 
		from completeCC_onProperties
		return 1
	end try

	begin catch
		return @@Error * -1
	end catch
		
END
GO
