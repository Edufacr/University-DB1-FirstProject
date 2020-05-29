USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_insertProperty]    Script Date: 5/27/2020 9:40:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/27
-- Description:	Insert a new property into dbo.DB1P_Properties
-- =============================================
ALTER procedure [dbo].[SP_insertProperty] @pName varchar(50), @pValue money, @pAddress varchar(100)
as
begin
	set nocount on;
	begin try
		insert into dbo.DB1P_Properties (Name, Value, Address, Active)
		values (@pName, @pValue, @pAddress, 1);
		return 1
	end try
	begin catch
		return @@Error * -1
	end catch		
end
