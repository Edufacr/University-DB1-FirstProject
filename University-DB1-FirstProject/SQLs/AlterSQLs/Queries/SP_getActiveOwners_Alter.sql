USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_getActiveOwners]    Script Date: 5/31/2020 11:15:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/31
-- Description:	Query all active owners of the DB
-- =============================================
ALTER PROCEDURE [dbo].[SP_getActiveOwners]

AS
BEGIN
	
	begin try
		select o.Name, o.DocValue, o.DocType
		from dbo.activeOwners as o
		return 1
	end try
	
	begin catch
		return @@Error * -1
	end catch

END
