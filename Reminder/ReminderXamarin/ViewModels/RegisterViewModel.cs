using System.Windows.Input;
using ReminderXamarin.Helpers;
using ReminderXamarin.Pages;
using Xamarin.Forms;

namespace ReminderXamarin.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel()
        {
            RegisterCommand = new Command(RegisterCommandExecute);
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsValid { get; set; } = true;

        public ICommand RegisterCommand { get; set; }

        public void RegisterCommandExecute()
        {
            if (Password != ConfirmPassword)
            {
                // AlertService.DisplayAlert("");
                IsValid = false;
            }
            else
            {
                var authResult = AuthenticationManager.Register(UserName, Password);
                if (authResult)
                {
                    Application.Current.MainPage = new LoginPage();
                    IsValid = true;
                }
                else
                {
                    // AlertService.DisplayAlert("");
                    IsValid = false;
                }
            }
        }
    }
}