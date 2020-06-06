USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_getPropertiesOfOwner]    Script Date: 6/1/2020 1:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/6/1
-- Description:	Query the properties of an owner.
-- =============================================
ALTER PROCEDURE [dbo].[SP_getPropertiesOfOwner]
	@pDocValue VARCHAR(30),
	@pDocType int
AS
BEGIN

	declare @OwnerId int
	declare @DocType_Id int
	begin try

		select @DocType_Id = t.Id
		from DB1P_Doc_Id_Types as t
		where t.Name = @pDocType
		
		select @OwnerId = o.Id
		from activeOwners as o
		where o.DocValue = @pDocValue and o.DocType_Id = @DocType_Id

		select r.PropertyName, r.PropertyAddress, r.PropertyValue, r.PropertyNumber
		from activePropertiesOwnersRelations as r
		where r.ownerId = @OwnerId

		return 1

	end try

	begin catch
		
		return @@Error * -1

	end catch
		
END
