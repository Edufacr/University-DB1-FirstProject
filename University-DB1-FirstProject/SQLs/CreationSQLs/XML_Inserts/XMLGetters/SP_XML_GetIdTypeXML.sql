-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 02/06/2020
-- Description:	Gets IdTypes XML
-- =============================================
CREATE PROCEDURE SP_XML_GetIdTypeXML
	-- Add the parameters for the stored procedure here
    @xmlDocument xml OUTPUT
AS
BEGIN
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
        SELECT @xmlDocument = 
            '<TipoDocIdentidad>
                <TipoDocId codigoDoc="1" descripcion="Cedula Nacional"/>
                <TipoDocId codigoDoc="2" descripcion="Cedula Residente"/>
                <TipoDocId codigoDoc="3" descripcion="Pasaporte"/>
                <TipoDocId codigoDoc="4" descripcion="Cedula Juridica"/>
                <TipoDocId codigoDoc="5" descripcion="Registro Civil"/>
                <TipoDocId codigoDoc="6" descripcion="Cedula Extranjera"/>
            </TipoDocIdentidad>'
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO