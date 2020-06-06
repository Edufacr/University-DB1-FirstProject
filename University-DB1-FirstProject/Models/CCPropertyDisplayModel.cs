using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class CCPropertyDisplayModel
    {
        [Required][Display (Name = "Concepto de Cobro")] public string ChargeConceptName;
        [Required][Display (Name = "Días de Expiración")] public int ExpirationDays;
        [Required][Display (Name = "Tasa de Intereses Moratorios")] public float MoratoryInterestRate;
        [Required][Display (Name = "Día Emisión Recibo")] public int ReciptEmisionDay;
        [Required][Display (Name = "Fecha Inicio")]  public string BeginDate;
        [Required][Display (Name = "Fecha Fin")]  public string EndDate;
    }
}