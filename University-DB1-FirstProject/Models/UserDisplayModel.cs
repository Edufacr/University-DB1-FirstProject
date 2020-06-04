using System.ComponentModel.DataAnnotations;


namespace University_DB1_FirstProject.Models
{
    public class UserDisplayModel
    {
        [Required]
        [Display( Name = "Usuario")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}