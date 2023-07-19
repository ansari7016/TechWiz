using System.ComponentModel.DataAnnotations;

namespace TechWizProject.Models
{
    public class Register
    {
        public  int RegisterId { get; set; }

        [StringLength(25), MinLength(3)]
        [Required]
        public string Name { get; set; }

        [StringLength(25)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(25),MinLength(8)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(25), MinLength(8)]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }

        public int Age { get; set; }

        [StringLength(250)]
        [Required]
        public string Address { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
    }
}
