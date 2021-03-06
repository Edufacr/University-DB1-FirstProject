USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_getActivePropertyOwners]    Script Date: 6/1/2020 1:03:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/6/1
-- Description:	Query all active properties-owners relations.
-- =============================================
ALTER PROCEDURE [dbo].[SP_getActivePropertyOwners]

AS
BEGIN

	begin try
		select *
		from activePropertiesOwnersRelations as po
		return 1
	end try

	begin catch
		return @@Error * -1
	end catch
		
END
