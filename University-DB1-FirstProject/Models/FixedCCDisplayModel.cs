using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class FixedCCDisplayModel
    {
        [Required] [Display(Name = "Monto")]
        public float Amount;
    }
}