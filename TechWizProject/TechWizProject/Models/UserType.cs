using System.ComponentModel.DataAnnotations;

namespace TechWizProject.Models
{
    public class UserType
    {
        public int UserTypeId { get; set; }

        [StringLength(50),MinLength(3)]
        [Display(Name = "User Type")]
        public string Typename { get; set; }
    }
}
