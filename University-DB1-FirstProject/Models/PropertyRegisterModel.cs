using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class PropertyRegisterModel
    {

        [Required]
        public string Address { get; set; }
        
        [Required]
        public float Value { get; set; }
        
        [Required]
        public int PropertyNumber { get; set; }
        
    }
}