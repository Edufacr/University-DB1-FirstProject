using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class OwnerRegisterModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string DocTypeId { get; set; }
        
        [Required]
        public int DocValue { get; set; }

    }
}