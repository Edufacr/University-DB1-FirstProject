USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_getPropertyInfoByAddress]    Script Date: 6/1/2020 12:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/6/1
-- Description:	Query the information of a property by address.
-- =============================================
ALTER PROCEDURE [dbo].[SP_getPropertyInfoByAddress]
	@pAddress varchar(50)
AS
BEGIN

	begin try
		select p.Name, p.Address, p.Value, p.PropertyNumber
		from dbo.activeProperties as p
		where Address = @pAddress
		return 1
	end try

	begin catch
		return @@Error * -1
	end catch
END
