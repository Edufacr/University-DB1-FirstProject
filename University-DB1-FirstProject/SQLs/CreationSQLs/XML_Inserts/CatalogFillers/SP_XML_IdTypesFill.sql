SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 01/06/2020
-- Description:	Loads the initial IdTypes from a XML
-- =============================================
CREATE PROCEDURE SP_XML_IdTypesFill
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
		EXEC SP_XML_GetIdTypeXML @xmlDocument OUTPUT;
		EXEC sp_xml_preparedocument @docHandle OUTPUT, @xmlDocument; 
		INSERT INTO DB1P_Doc_Id_Types(Id,Name)
		SELECT *
		FROM OPENXML(@docHandle,'/TipoDocIdentidad/TipoDocId') with (Id int '@codigoDoc', Name varchar(50) '@descripcion');
		EXEC sp_xml_removedocument @docHandle; -- Remove the internal representation of the XML document.
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH

END
GO