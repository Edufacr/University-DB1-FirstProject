using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace University_DB1_FirstProject.Models
{
    public class PropertyRegisterModel
    {
        
        [Required] 
        [Display(Name = "Nombre")] 
        public string Name { get; set; }
        
        [Required] 
        [Display(Name = "Dirección")] 
        public string Address { get; set; }
        
        [Required] 
        [Display(Name = "Número Finca")] 
        public int PropertyNumber { get; set; }
        
        [Required] 
        [Display(Name = "Valor")] 
        public float Value { get; set; }
        
    }
}