USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_insertPropertyOwner]    Script Date: 5/28/2020 11:41:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/28
-- Description:	Alters [SP_insertPropertyOwner] procedure.
-- =============================================
alter procedure dbo.SP_insertPropertyOwner 
	@pPropertyNumber int, 
	@pOwnerDocValue varchar(30),
	@pOwnerDocType varchar(50)
as
begin

	declare @Property_Id int;
	declare @Owner_Id int;
	declare @OwnerDocType_Id int;

	--begin try

		select @OwnerDocType_Id = t.Id
		from DB1P_Doc_Id_Types as t
		where t.Name  = @pOwnerDocType

		select @Owner_Id = o.Id
		from dbo.activeOwners as o
		where  o.DocValue = @pOwnerDocValue

		select @Property_Id = p.Id
		from dbo.activeProperties as p
		where p.PropertyNumber = @pPropertyNumber

		insert into dbo.DB1P_PropertyOwners (Property_Id, Owner_Id, Active)
		values (@Property_Id, @Owner_Id, 1);
		return 1
	--end try
	--begin catch
	--	return @@Error * -1
	--end catch		
end

