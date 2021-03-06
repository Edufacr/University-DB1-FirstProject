USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_deletePropertyOwner]    Script Date: 5/30/2020 8:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/30
-- Description:	Delete  an element from DB1P_PropertyOwners.
-- =============================================
ALTER PROCEDURE [dbo].[SP_deletePropertyOwner]
		@pOwnerDocValue int, 
		@pOwnerDocType int,
		@pPropertyPropertyNumber int
AS
BEGIN
	begin try

		declare @OwnerId int;
		declare @PropertyId int;
		declare @OwnerDocType_Id int;

		select @OwnerDocType_Id = t.Id
		from DB1P_Doc_Id_Types as t
		where t.Name = @pOwnerDocType


		select @OwnerId = Id 
		from dbo.DB1P_Owners 
		where DocValue = @pOwnerDocValue and DocType_Id = @OwnerDocType_Id
		
		select @PropertyId = Id
		from dbo.DB1P_Properties
		where PropertyNumber = @pPropertyPropertyNumber

		update dbo.DB1P_PropertyOwners
		set Active = 0
		where Property_Id = @PropertyId and Owner_Id = @OwnerId
		return 1
	end try
	begin catch
		return @@Error * -1
	end catch
END
