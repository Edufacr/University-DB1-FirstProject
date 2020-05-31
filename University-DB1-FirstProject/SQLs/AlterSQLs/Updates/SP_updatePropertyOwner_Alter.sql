USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_updatePropertyOwner]    Script Date: 5/30/2020 4:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/30
-- Description:	Updates an element of the table DB1P_PropertyOwners.
-- =============================================
ALTER PROCEDURE [dbo].[SP_updatePropertyOwner] 	
	
	@pOwnerDocValue int, 
	@pPropertyPropertyNumber int,

	@pNewOwnerDocValue int, 
	@pNewPropertyPropertyNumber int

AS
BEGIN
	
	declare @NewPropertyId int;
	declare @NewOwnerId int;
	declare @OwnerId int;
	declare @PropertyId int;


	begin try

		select @OwnerId = Id 
		from dbo.DB1P_Owners 
		where DocValue = @pOwnerDocValue
		
		select @PropertyId = Id
		from dbo.DB1P_Properties
		where PropertyNumber = @pOwnerDocValue

		select @NewOwnerId = Id
		from dbo.DB1P_Owners 
		where DocValue = @pNewOwnerDocValue

		select @NewPropertyId = Id
		from dbo.DB1P_Properties
		where PropertyNumber = @pNewOwnerDocValue

		update dbo.DB1P_PropertyOwners
		set Property_Id = @NewPropertyId,
			Owner_Id = @NewOwnerId
		where Property_Id = @PropertyId and Owner_Id = @OwnerId

		return 1

	end try
	begin catch
		return @@Error * -1
	end catch	
END
