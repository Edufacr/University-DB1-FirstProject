using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class PropertyDisplayModel
    {

        [Required]
        [Display(Name = "Dirección")]
        public string Address { get; set; }
        
        [Required]
        [Display(Name = "Valor")]
        public float Value { get; set; }
        
        [Required]
        [Display(Name = "Número Finca")]
        public int PropertyNumber { get; set; }
    }
}