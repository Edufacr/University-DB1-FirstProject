USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_updateProperty]    Script Date: 5/30/2020 4:34:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/30
-- Description:	Updates an element of the table DB1P_Properties.
-- =============================================
ALTER PROCEDURE [dbo].[SP_updateProperty] 
	@pPropertyNumber int, 
	@pNewName varchar(50), 
	@pNewValue money, 
	@pNewAddress varchar(100),
	@pNewPropertyNumber int
AS
BEGIN
	begin try
		update dbo.DB1P_Properties
		set Name = @pNewName, 
			Value = @pNewValue,
			Address = @pNewAddress,
			PropertyNumber = @pNewPropertyNumber
		where PropertyNumber = @pPropertyNumber
	end  try
	begin catch
		return @@Error * -1
	end catch	

END
