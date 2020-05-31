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
	@pDocValue int, 
	@pNewName varchar(50),
	@pNewDocValue int,
	@pNewDocType_Id int

AS
BEGIN
	begin try
		update dbo.DB1P_Owners
		set Name = @pNewName,
			DocValue = @pNewDocValue,
			DocType_Id = @pNewDocType_Id
		where DocValue = @pDocValue
		return 1
	end try
	begin catch
		return @@Error * -1
	end catch	

END
