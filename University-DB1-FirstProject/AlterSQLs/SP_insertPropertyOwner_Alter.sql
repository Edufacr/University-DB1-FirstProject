USE [DB1_Proyect]
GO
/****** Object:  StoredProcedure [dbo].[SP_insertPropertyOwner]    Script Date: 5/28/2020 11:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/28
-- Description:	Insert a property owner to DB1P_PropertyOwners
-- =============================================
alter procedure dbo.SP_insertPropertyOwner @pProperty_Id int, @pOwner_Id int
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

