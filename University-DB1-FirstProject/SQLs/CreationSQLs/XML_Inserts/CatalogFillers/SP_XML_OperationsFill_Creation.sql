SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 06/06/2020
-- Description:	Loads the operations from XML
-- =============================================
CREATE PROCEDURE SP_XML_OperationsFill
	-- Add the parameters for the stored procedure here
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;
BEGIN TRY
	DECLARE @docHandle int;
	DECLARE @xmlDocument xml;
	DECLARE @LegalOwnersToInsert TABLE (LegalOwnerDocValue VARCHAR(30),ResponsibleName VARCHAR(50),ResponsibleDocType_Id int,Responsible_DocValue VARCHAR(50),Active bit)
	DECLARE @PropertyOwnersToInsert TABLE (PropertyNum int,DocValue VARCHAR(30),Active bit) 		
	DECLARE @CC_onPropertiesToInsert TABLE (ChargeConcept_Id int,PropertyNum int,BeginDate date,EndDate date,Active bit)
	DECLARE @PropertiesUsers TABLE (Username VARCHAR(50),PropertyNum int,Active bit)
	BEGIN TRANSACTION
		EXEC SP_XML_GetOperationsXML @xmlDocument OUTPUT;
		EXEC sp_xml_preparedocument @docHandle OUTPUT, @xmlDocument; 
		INSERT INTO DB1P_Properties
		SELECT Name = null, Value, Address,PropertyNum,Active = 1 FROM OPENXML(@docHandle,'/Operaciones_por_Dia/OperacionDia/Propiedad') with (Value MONEY '@Valor',Address VARCHAR(100) '@Direccion',PropertyNum int '@NumFinca',Date VARCHAR(50) '../@fecha');
	
		INSERT INTO DB1P_Owners
		SELECT Name, DocType_Id,DocValue,Active = 1 FROM OPENXML(@docHandle,'/Operaciones_por_Dia/OperacionDia/Propietario') with (Name VARCHAR(50) '@Nombre',DocType_Id int '@TipoDocIdentidad',DocValue VARCHAR(30) '@identificacion',Date VARCHAR(50) '../@fecha');
	
		INSERT INTO DB1P_Users
		SELECT Username, Password, UserType = 0,Active =1 from OPENXML(@docHandle,'/Operaciones_por_Dia/OperacionDia/Usuario ') with (Username VARCHAR(50) '@Nombre', Password VARCHAR(50) '@password')
	
		INSERT INTO @LegalOwnersToInsert
		SELECT LegalOwnerDocValue,ResponsibleName, ResponsibleDocType_Id,Responsible_DocValue,Active=1 FROM OPENXML(@docHandle,'/Operaciones_por_Dia/OperacionDia/PersonaJuridica') with (LegalOwnerDocValue VARCHAR(30) '@docidPersonaJuridica',ResponsibleName VARCHAR(50) '@Nombre',ResponsibleDocType_Id int '@TipDocIdRepresentante',Responsible_DocValue VARCHAR(50) '@DocidRepresentante') ;
		INSERT INTO DB1P_LegalOwners
		SELECT Id,ResponsibleName,ResponsibleDocType_Id,Responsible_DocValue,O.Active FROM @LegalOwnersToInsert as LO
		INNER JOIN DB1P_Owners as O on	O.DocValue = LO.LegalOwnerDocValue; 

	
		INSERT INTO @PropertyOwnersToInsert
		SELECT PropertyNum,DocValue,Active = 1 FROM OPENXML(@docHandle,'/Operaciones_por_Dia/OperacionDia/PropiedadVersusPropietario') with (PropertyNum int '@NumFinca',DocValue VARCHAR(30) '@identificacion');
		INSERT INTO DB1P_PropertyOwners
		SELECT P.Id,O.Id,Active =1 FROM @PropertyOwnersToInsert as PO
		INNER JOIN DB1P_Owners as O on	PO.DocValue = O.DocValue
		INNER JOIN DB1P_Properties as P on PO.PropertyNum = P.PropertyNumber
	
		INSERT INTO @CC_onPropertiesToInsert
		SELECT ChargeConcept_Id ,PropertyNum,BeginDate,EndDate = null,Active = 1 FROM OPENXML(@docHandle,'/Operaciones_por_Dia/OperacionDia/ConceptoCobroVersusPropiedad ') with (ChargeConcept_Id int '@idcobro',PropertyNum int '@NumFinca',BeginDate date '../@fecha') 
		INSERT INTO DB1P_CC_onProperties
		SELECT P.Id,CC.Id,BeginDate,EndDate,Active =1 FROM @CC_onPropertiesToInsert as CP
		INNER JOIN DB1P_ChargeConcepts as CC on	CP.ChargeConcept_Id = CC.Id
		INNER JOIN DB1P_Properties as P on CP.PropertyNum = P.PropertyNumber
	
		INSERT INTO @PropertiesUsers
		SELECT Username, PropertyNum,Active=1 from OPENXML(@docHandle,'/Operaciones_por_Dia/OperacionDia/UsuarioVersusPropiedad ') with (Username VARCHAR(50) '@nombreUsuario', PropertyNum int '@NumFinca')
		INSERT INTO DB1P_PropertiesUsers
		SELECT P.Id,U.Id,Active =1 FROM @PropertiesUsers as PU
		INNER JOIN DB1P_Users as U on U.Username = PU.Username
		INNER JOIN DB1P_Properties as P on PU.PropertyNum = P.PropertyNumber
		EXEC sp_xml_removedocument @docHandle;				 																	  
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH

END
GO