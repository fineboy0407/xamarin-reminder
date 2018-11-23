using Reminder.Helpers;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Dto
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = ConstantsHelper.PasswordErrorMessage, MinimumLength = 4)]
        public string Password { get; set; }
    }
}