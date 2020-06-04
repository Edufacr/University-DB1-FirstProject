using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class LegalOwnerDisplayModel
    {
        [Required]
        [Display( Name = "Nombre Entidad")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Cédula Jurídica")]
        public int DocValue { get; set; }
        
        [Required]
        [Display(Name = "Nombre Responsable")]
        public string ResponsibleName { get; set; }
        
        [Required]
        [Display(Name = "ID Responsable")]
        public int RespDocValue { get; set; }
        
        [Required]
        [Display(Name = "Tipo ID Responsable")]
        public string RespDocTypeId { get; set; }

    }
}