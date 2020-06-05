using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class OwnerDisplayModel
    {
        [Required]
        [Display( Name = "Nombre")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Tipo Documento")]
        public int DocTypeId { get; set; }
        
        [Required]
        [Display(Name = "ID")]
        public string DocValue { get; set; }

    }
}