using System.ComponentModel.DataAnnotations;
using Reminder.Helpers;

namespace IdentityServer.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = ConstantsHelper.EmailIsEmpty)]
        public string Email { get; set; }

        [Required(ErrorMessage = ConstantsHelper.PasswordIsEmpty)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = ConstantsHelper.PasswordIncorrect)]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}