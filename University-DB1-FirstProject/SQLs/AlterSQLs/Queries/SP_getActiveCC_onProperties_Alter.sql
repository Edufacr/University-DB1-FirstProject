USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_getActiveCC_onProperties]    Script Date: 6/1/2020 12:51:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/6/1
-- Description:	Query all active charge concepts on properties.
-- =============================================
ALTER PROCEDURE [dbo].[SP_getActiveCC_onProperties]

AS
BEGIN
	
	begin try
		select * 
		from completeCC_onProperties
		return 1
	end try

	begin catch
		return @@Error * -1
	end catch
		
END
