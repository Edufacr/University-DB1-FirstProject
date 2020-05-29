USE [DB1_Proyect]
GO
/****** Object:  StoredProcedure [dbo].[SP_insertOwner]    Script Date: 5/28/2020 11:10:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Gutiérrez Cordero
-- Create date: 2020/5/27
-- Description:	Insert a new property into dbo.DB1P_Properties
-- =============================================
ALTER procedure [dbo].[SP_insertOwner] @pName varchar(50), @pDocValue int, @pDocType_Id varchar(100)
as
begin
	begin try
		insert into dbo.DB1P_Owners (Name, DocValue, DocType_Id, Active)
		values (@pName, @pDocValue, @pDocType_Id, 1);
		return 1
	end try
	begin catch
		return @@Error * -1
	end catch		
end
