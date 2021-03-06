USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_updateOwner]    Script Date: 5/30/2020 4:34:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/30
-- Description:	Updates an element of the table DB1P_Owners.
-- =============================================
ALTER PROCEDURE [dbo].[SP_updateOwner] 
	@pDocValue VARCHAR(30), 
	@pDocType  int, 
	@pNewName varchar(50),
	@pNewDocValue VARCHAR(30),
	@pNewDocType_Id int

AS
BEGIN

	declare @DocType_Id int

	begin try

		select @DocType_Id = t.Id
		from DB1P_Doc_Id_Types as t
		where t.Name = @pDocType

		update dbo.DB1P_Owners
		set Name = @pNewName,
			DocValue = @pNewDocValue,
			DocType_Id = @pNewDocType_Id
		where DocValue = @pDocValue and DocType_Id = @DocType_Id
		return 1
	end try
	begin catch
		return @@Error * -1
	end catch	

END
