using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class CC_onPropertyDisplayModel
    {
        [Required][Display (Name = "Concepto de Cobro")] public string ChargeConceptName;
        [Required][Display (Name = "Días de Expiración")] public string ExpirationDays;
        [Required][Display (Name = "Tasa de Intereses Moratorios")] public string MoratoryInterestRate;
        [Required][Display (Name = "Día Emisión Recibo")] public string ReciptEmisionDay;
        [Required][Display (Name = "Fecha Inicio")]  public string BeginDate;
        [Required][Display (Name = "Fecha Fin")]  public string EndDate;
    }
}