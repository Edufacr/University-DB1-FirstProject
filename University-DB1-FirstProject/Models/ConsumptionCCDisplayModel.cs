using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class ConsumptionCcDisplayModel
    {
        [Required] [Display(Name = "Consumo Metro Cúbico")]
        public int ConsumptionM3;
    }
}