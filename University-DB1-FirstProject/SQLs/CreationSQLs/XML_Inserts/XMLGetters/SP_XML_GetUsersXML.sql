-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 02/06/2020
-- Description:	Gets Users XML
-- =============================================
CREATE PROCEDURE SP_XML_GetUsersXML
	-- Add the parameters for the stored procedure here
    @xmlDocument OUTPUT
AS
BEGIN
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
        SELECT @xmlDocument = 
        '<Administrador>
            <UsuarioAdmi user="Jquiros" password="123hola" tipo="administrador"/>
            <UsuarioAdmi user="Jperez" password="123mama" tipo="administrador"/>	
            <UsuarioAdmi user="Kipanda" password="1211pez" tipo="administrador"/>
        </Administrador>'
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO