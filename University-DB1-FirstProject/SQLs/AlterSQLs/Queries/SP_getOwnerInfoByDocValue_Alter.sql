USE [DB1-FirstProject]
GO
/****** Object:  StoredProcedure [dbo].[SP_getOwnerInfo]    Script Date: 6/1/2020 12:06:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_getOwnerInfoByDocValue]
	@pDocValue int, 
	@pDocType_Id int
AS
BEGIN

	declare @Id int

	begin try

		select @Id = o.Id
		from activeOwners as o
		where DocValue = @pDocValue and DocType_Id = @pDocType_Id

		if @pDocType_Id = 4
			begin
				select * 
				from dbo.completeLegalOwners
				where Id = @Id
			end
		else
			begin
				select *
				from dbo.activeOwners
				where Id = @Id
			end

		return 1

	end try

	begin catch

		return @@Error * -1

	end catch

END
