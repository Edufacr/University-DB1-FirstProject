using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class LegalOwnerRegisterModel
    {
        [Required]
        public string DocValue { get; set; }
        
        [Required]
        public string ResponsibleName { get; set; }
        
        [Required]
        public int RespDocValue { get; set; }
        
        [Required]
        public string RespDocTypeId { get; set; }
    }
}