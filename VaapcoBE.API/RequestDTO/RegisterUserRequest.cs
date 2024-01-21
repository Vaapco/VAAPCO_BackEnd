using System.ComponentModel.DataAnnotations;

namespace VaapcoBE.API.RequestDTO
{
    public class RegisterUserRequest
    {
        [Required]
        public string EmailId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
