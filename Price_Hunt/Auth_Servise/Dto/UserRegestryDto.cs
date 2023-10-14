using System.ComponentModel.DataAnnotations;

namespace Auth_Servise.Dto
{
    public class UserRegestryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
