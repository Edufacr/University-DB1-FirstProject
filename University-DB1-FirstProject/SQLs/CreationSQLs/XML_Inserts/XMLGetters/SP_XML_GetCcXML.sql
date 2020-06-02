-- =============================================
-- Author:		Eduardo Madrigal Marín
-- Create date: 02/06/2020
-- Description:	Gets Users XML
-- =============================================
CREATE PROCEDURE SP_XML_GetCcXML
	-- Add the parameters for the stored procedure here
    @xmlDocument OUTPUT
AS
BEGIN
    -- Insert statements for procedure here
BEGIN TRY
	BEGIN TRANSACTION
        SELECT @xmlDocument = 
        '<Conceptos_de_Cobro>
            <conceptocobro id="1" Nombre="Agua" DiaCobro="25" QDiasVencimiento="4" EsImpuesto="No" EsRecurrente="Si" EsFijo="No" TasaInteresMoratoria="5.2" TipoCC="CC Consumo" Monto="" ValorM3="500" ValorPorcentaje="" />
            <conceptocobro id="2" Nombre="Patente Licores" DiaCobro="8" QDiasVencimiento="12" EsImpuesto="Si" EsRecurrente="Si" EsFijo="Si" TasaInteresMoratoria="2.6" TipoCC="CC Fijo" Monto="50000" ValorM3="" ValorPorcentaje="" />
            <conceptocobro id="3" Nombre="impuesto Propiedad" DiaCobro="8" QDiasVencimiento="12" EsImpuesto="Si" EsRecurrente="Si" EsFijo="No" TasaInteresMoratoria="1.5" TipoCC="CC Fijo" Monto="" ValorM3="" ValorPorcentaje="5.0" />
            <conceptocobro id="4" Nombre="Recolectar Basura" DiaCobro="4" QDiasVencimiento="5" EsImpuesto="No" EsRecurrente="Si" EsFijo="Si" TasaInteresMoratoria="2.2" TipoCC="CC Fijo" Monto="3000" ValorM3="" ValorPorcentaje="" />
            <conceptocobro id="5" Nombre="Mantenimiento de Parques" DiaCobro="3" QDiasVencimiento="7" EsImpuesto="Si" EsRecurrente="Si" EsFijo="Si" TasaInteresMoratoria="0.87" TipoCC="CC Fijo" Monto="970" ValorM3="" ValorPorcentaje="" />
            <conceptocobro id="6" Nombre="Reconexion de Agua" DiaCobro="15" QDiasVencimiento="10" EsImpuesto="No" EsRecurrente="Si" EsFijo="Si" TasaInteresMoratoria="3.8" TipoCC="CC Consumo" Monto="780" ValorM3="" ValorPorcentaje="" />
            <conceptocobro id="7" Nombre="Impuesto a la Renta" DiaCobro="5" QDiasVencimiento="15" EsImpuesto="Si" EsRecurrente="Si" EsFijo="Si" TasaInteresMoratoria="12.6" TipoCC="CC Fijo" Monto="4521" ValorM3="" ValorPorcentaje="" />
            <conceptocobro id="8" Nombre="Mantenimiento de Parques" DiaCobro="7" QDiasVencimiento="6" EsImpuesto="No" EsRecurrente="No" EsFijo="Si" TasaInteresMoratoria="0.32" TipoCC="CC Consumo" Monto="7850" ValorM3="" ValorPorcentaje="" />
            <conceptocobro id="9" Nombre="Aseo de sitios Publico" DiaCobro="1" QDiasVencimiento="10" EsImpuesto="No" EsRecurrente="Si" EsFijo="Si" TasaInteresMoratoria="7.8" TipoCC="CC Consumo" Monto="580" ValorM3="" ValorPorcentaje="" />
        </Conceptos_de_Cobro>'
	COMMIT
END TRY
BEGIN CATCH
	ROLLBACK
	return @@Error * -1
END CATCH
END
GO