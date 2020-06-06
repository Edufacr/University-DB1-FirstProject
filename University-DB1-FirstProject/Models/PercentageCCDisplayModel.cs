using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class PercentageCCDisplayModel
    {
        [Required] [Display(Name = "Valor Porcentaje")]
        public float Percentage;
    }
}