USE [DB1-FirstProject]
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
-- Create date: 2020/5/28
-- Description:	Insert a property owner to DB1P_PropertyOwners
-- =============================================
create procedure dbo.SP_insertPropertyOwner @pProperty_Id int, @pOwner_Id int
as
begin
	begin try
		insert into dbo.DB1P_PropertyOwners (Property_Id, Owner_Id, Active)
		values (@pProperty_Id, @pOwner_Id, 1);
		return 1
	end try
	begin catch
		return @@Error * -1
	end catch		
end

