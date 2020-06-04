SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 01/06/2020
-- Description:	Loads the initial users from a XML
-- =============================================
CREATE PROCEDURE SP_XML_CcFill
	-- Add the parameters for the stored procedure here
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;
BEGIN TRY
	BEGIN TRANSACTION
		DECLARE @docHandle int;
		DECLARE @xmlDocument xml;
		EXEC SP_XML_GetCcXML @xmlDocument OUTPUT;
		EXEC sp_xml_preparedocument @docHandle OUTPUT, @xmlDocument; 

		INSERT INTO DB1P_Users (Username,Password, UserType,Active)
		SELECT Username,Password,UserType = 1 ,Active = 1  
		FROM OPENXML(@docHandle,'/Administrador/UsuarioAdmi') with (Username varchar(50) '@user',Password varchar(50) '@password',UserType varchar(20) '@tipo')
		where UserType = 'administrador';
		INSERT INTO DB1P_Users (Username,Password, UserType,Active)
		SELECT Username,Password,UserType = 0 ,Active = 1  FROM OPENXML(@docHandle,'/Administrador/UsuarioAdmi') with (Username varchar(50) '@user',Password varchar(50) '@password',UserType varchar(20) '@tipo')
		where UserType != 'administrador';
		EXEC sp_xml_removedocument @docHandle; -- Remove the internal representation of the XML document.
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH

END
GO