using System.ComponentModel.DataAnnotations;

namespace University_DB1_FirstProject.Models
{
    public class CC_onPropertyRegisterModel
    {
        [Required] public int PropertyNumber;
        [Required] public string ChargeConceptName;
        [Required] public string BeginDate;
    }
}