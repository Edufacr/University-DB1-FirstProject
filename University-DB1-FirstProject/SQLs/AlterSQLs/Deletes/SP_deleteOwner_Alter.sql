USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_deleteOwner]    Script Date: 5/30/2020 8:14:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/30
-- Description:	Delete  an element from DB1P_Owners.
-- =============================================
ALTER PROCEDURE [dbo].[SP_deleteOwner]
	@pDocValue int
AS
BEGIN
	begin try
		update dbo.DB1P_Owners
		set Active = 0
		where DocValue = @pDocValue
		return 1
	end try
	begin catch
		return @@Error * -1
	end catch
END
