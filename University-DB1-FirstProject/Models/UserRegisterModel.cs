using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class UserRegisterModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int UserType { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}