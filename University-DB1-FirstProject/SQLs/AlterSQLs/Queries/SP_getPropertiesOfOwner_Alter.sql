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
	@pDocValue int,
	@pDocType_Id int
AS
BEGIN

	declare @OwnerId int

	begin try
		
		select @OwnerId = o.Id
		from activeOwners as o
		where o.DocValue = @pDocValue and o.DocType_Id = @pDocType_Id

		select * 
		from activePropertiesOwnersRelations as r
		where r.ownerId = @OwnerId

		return 1

	end try

	begin catch
		
		return @@Error * -1

	end catch
		
END
