USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_deleteProperty]    Script Date: 5/30/2020 8:14:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/30
-- Description:	Delete  an element from DB1P_Properties.
-- =============================================
ALTER PROCEDURE [dbo].[SP_deleteProperty]
	@pPropertyNumber int
AS
BEGIN
	begin try
		update dbo.DB1P_Properties
		set Active = 0
		where PropertyNumber = @pPropertyNumber
		return 1
	end try
	begin catch
		return @@Error * -1
	end catch
END
