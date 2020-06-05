using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class LegalOwnerRegisterModel
    {
        [Required]
        public int DocValue { get; set; }
        
        [Required]
        public string ResponsibleName { get; set; }
        
        [Required]
        public int RespDocValue { get; set; }
        
        [Required]
        public int RespDocTypeId { get; set; }
    }
}