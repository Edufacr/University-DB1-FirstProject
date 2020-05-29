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
-- Description:	Insert a new property into dbo.DB1P_Properties
-- =============================================
create procedure dbo.SP_insertProperty @pName varchar, @pValue money, @pAddress varchar
as
begin
	set nocount on;
	begin try
			insert into dbo.DB1P_Properties (Name, Value, Address, Active)
			values (@pName, @pValue, @pAddress, 1);
		return 1
	end try
	begin catch
		return @@Error * -1
	end catch		
end
go
